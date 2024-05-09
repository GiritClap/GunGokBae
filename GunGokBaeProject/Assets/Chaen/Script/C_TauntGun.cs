using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        bulletCntText.text = "Taunt Gun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //좌클릭
        {
            tauntGunMuzzleFlash.Play();
            ShotBullet();
        }
    }

    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bul = Instantiate(bulletFactory, firePosition.transform.position, firePosition.transform.rotation);
        bul.GetComponent<Rigidbody>().AddForce((bulletDirection.transform.position - firePosition.transform.position) * Time.deltaTime * bulletSpeed * 700f);
        Destroy(bul, 5f);
    }
}
