using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GroundGun : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //좌클릭
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
