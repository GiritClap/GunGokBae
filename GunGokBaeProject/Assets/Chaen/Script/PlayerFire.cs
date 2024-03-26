using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;

    //�Ѿ� ����Ʈ ������Ʈ
    public GameObject bulletEffect;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //��Ŭ��
        {
            ShotBigBullet();
        }

        if (Input.GetButtonDown("Fire2")) //��Ŭ��
        {
            ShotRayBullet();
        }
    }

    private void ShotBigBullet() // �Ϲ����� �Ѿ� �߻�
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

    private void ShotRayBullet() // ray �� �̿��� �Ѿ� �߻�
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo = new RaycastHit();

        if(Physics.Raycast(ray, out hitInfo, 1000)) {
            // �ǰ� ����Ʈ
            GameObject bE = Instantiate(bulletEffect);
            bE.transform.position = hitInfo.transform.position;
            ps = bE.GetComponent<ParticleSystem>();
            ps.Play();

            if (hitInfo.transform.gameObject.tag == "Enemy") //���� ��� destroy
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }
}
