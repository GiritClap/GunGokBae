using System.Collections;
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

    [SerializeField] float gunTimer;
    private float nowTime;
    private bool isShot;
    // Start is called before the first frame update
    void Start()
    {
        gunTimer = 45f;
        isShot = false;

        //bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        //bulletCntText.text = "GroundGun";
        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "Rocket Gun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //좌클릭
        {
            textGunTime.gameObject.SetActive(true);
            nowTime = gunTimer;
            isShot = true;
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
                ShotBullet();
                isShot = false;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            isShot = false;
            textGunTime.gameObject.SetActive(false);
        }
    }

    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

}
