using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_SpaceshipGun : MonoBehaviour
{

    public float fireTimer = 0; // 발사속도
    float timer = 0;

    public GameObject bullet;
    public GameObject bulletPos;
    public float bulletSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (fireTimer < timer)
        {
            if (Input.GetButton("Fire1")) //좌클릭
            {

                ShotRayBullet();

                timer = 0;
            }
        }

    }

    private void ShotRayBullet() // ray를 이용한 총알 발사
    {

        GameObject instatiateBullet = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        instatiateBullet.GetComponent<Rigidbody>().AddForce(instatiateBullet.transform.TransformDirection(new Vector3(0, 0, 1)) * Time.deltaTime * bulletSpeed);
        Destroy(instatiateBullet, 5f);
    }




}
