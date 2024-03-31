using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;

    //총알 이펙트 오브젝트
    public GameObject bulletEffect;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //좌클릭
        {
            ShotBigBullet();
        }

        if (Input.GetButtonDown("Fire2")) //우클릭
        {
            ShotRayBullet();
        }
    }

    private void ShotBigBullet() // 일반적인 총알 발사
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

    private void ShotRayBullet() // ray 를 이용한 총알 발사
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo = new RaycastHit();

        if(Physics.Raycast(ray, out hitInfo, 1000)) {
            // 피격 이펙트
            GameObject bE = Instantiate(bulletEffect);
            bE.transform.position = hitInfo.transform.position;
            ps = bE.GetComponent<ParticleSystem>();
            ps.Play();

            if (hitInfo.transform.gameObject.tag == "Enemy") //적일 경우 destroy
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }
}
