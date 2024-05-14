using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C_GroundGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public Text bulletCntText;
    public Image crosshair;

    public GameObject bulletDirection;
    public float bulletSpeed = 30f;
    public ParticleSystem groundGunMuzzleFlash;

    private bool isCool = false;

    public AudioClip groundGunSound;
    // Start is called before the first frame update
    void Start()
    {
        //bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        //bulletCntText.text = "GroundGun";
        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        isCool = this.GetComponentInParent<C_PlayerItem>().isCool;
        bulletCntText.text = "GroundGun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true && !isCool) //좌클릭
        {
            groundGunMuzzleFlash.Play();
            ShotBullet();
            M_SoundManager.instance.SFXPlay("groundgunShot", groundGunSound);
            this.GetComponentInParent<C_PlayerItem>().isCool = true;
            this.GetComponentInParent<C_PlayerItem>().SetCooldownTime(10f);
        }

    }

    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bul = Instantiate(bulletFactory, firePosition.transform.position, firePosition.transform.rotation);
        bul.GetComponent<Rigidbody>().AddForce((bulletDirection.transform.position - firePosition.transform.position) * Time.deltaTime * bulletSpeed * 700f);
        Destroy(bul, 5f);
    }
}
