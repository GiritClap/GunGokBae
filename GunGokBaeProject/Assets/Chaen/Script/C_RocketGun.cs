﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_RocketGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public Text bulletCntText;
    public Text textGunTime;
    public Image crosshair;

    [SerializeField] float gunTimer = 45f;
    private float nowTime;
    private bool isShot;

    public GameObject bulletDirection;
    public float bulletSpeed = 30f;
    public ParticleSystem rocketGunMuzzleFlash;
    public ParticleSystem roceketCharging;

    public GameObject playerBody;

    public AudioClip rocketShotClip;


    public AudioSource audioSource;
    public AudioClip rocketChargingClip;

    private bool isCool = false;

    // Start is called before the first frame update
    void Start()
    {
   
        isShot = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = rocketChargingClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        //bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        //bulletCntText.text = "GroundGun";
        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        isCool = this.GetComponentInParent<C_PlayerItem>().isCool;
        
        bulletCntText.text = "Rocket Gun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true && !isCool) //좌클릭
        {
            textGunTime.gameObject.SetActive(true);
            roceketCharging.Play();
            audioSource.Play();
            nowTime = gunTimer;
            isShot = true;

            this.GetComponentInParent<C_PlayerItem>().isCool = true;
            this.GetComponentInParent<C_PlayerItem>().SetCooldownTime(5f);
        }

        else if (Input.GetButtonUp("Fire1") && crosshair.gameObject.activeSelf == true)
        { //좌클릭{}
        
        }

        if (isShot)
        {
            nowTime -= Time.deltaTime;
            textGunTime.text = nowTime.ToString("F1");

            if(nowTime < 0)
            {
                roceketCharging.Stop();

                rocketGunMuzzleFlash.Play();
                textGunTime.gameObject.SetActive(false);
                ShotBullet();
                M_SoundManager.instance.SFXPlay("Rocket", rocketShotClip);

                playerBody.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.TransformDirection(0,0,-1) * 100f, ForceMode.Impulse);
                isShot = false;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            isShot = false;
            textGunTime.gameObject.SetActive(false);
            roceketCharging.Stop();
            audioSource.Stop();


        }
    }

    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bul = Instantiate(bulletFactory, firePosition.transform.position, firePosition.transform.rotation);
        bul.GetComponent<Rigidbody>().AddForce((bulletDirection.transform.position - firePosition.transform.position) * Time.deltaTime * bulletSpeed * 700f);
        Destroy(bul, 5f);
    }

}
