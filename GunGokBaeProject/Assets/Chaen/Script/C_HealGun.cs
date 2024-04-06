using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_HealGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    public Text bulletCntText;
    public Image crosshair;

    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = "HealGun";
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "HealGun";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //��Ŭ��
        {
            ShotBullet();
        }
    }

    private void ShotBullet() // �Ϲ����� �Ѿ� �߻�
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }
}
