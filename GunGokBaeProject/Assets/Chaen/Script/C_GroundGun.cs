using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_GroundGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public Text bulletCntText;
    public Image crosshair;

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
        bulletCntText.text = "GroundGun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //좌클릭
        {
            ShotBullet();
        }
    }

    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }
}
