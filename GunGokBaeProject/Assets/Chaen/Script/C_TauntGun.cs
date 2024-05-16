using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class C_TauntGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public Text bulletCntText;
    public Image crosshair;

    public GameObject bulletDirection;
    public float bulletSpeed = 30f;
    public ParticleSystem tauntGunMuzzleFlash;

    public AudioClip tauntShotClip;

    private bool isCool = false;

    // Start is called before the first frame update
    void Start()
    {
        //bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        //bulletCntText.text = "HealGun";
        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        isCool = this.GetComponentInParent<C_PlayerItem>().isCool;

        
        bulletCntText.text = "Taunt Gun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true && !isCool) //��Ŭ��
        {
            tauntGunMuzzleFlash.Play();
            ShotBullet();
            M_SoundManager.instance.SFXPlay("tauntShot", tauntShotClip);
            this.GetComponentInParent<C_PlayerItem>().isCool = true;
            this.GetComponentInParent<C_PlayerItem>().SetCooldownTime(5f);

        }
    }

    private void ShotBullet() // �Ϲ����� �Ѿ� �߻�
    {
        GameObject bul = Instantiate(bulletFactory, firePosition.transform.position, firePosition.transform.rotation);
        bul.GetComponent<Rigidbody>().AddForce((bulletDirection.transform.position - firePosition.transform.position) * Time.deltaTime * bulletSpeed * 700f);
        Destroy(bul, 5f);
    }
}
