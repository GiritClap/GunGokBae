using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class M_Shotgun : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    float max_Bullet_Cnt = 30; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 7; // ���� �� �� �ִ� �Ѿ� ��
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // �߻�ӵ�
    float timer = 0;

    public Image crosshair;

    public GameObject bullet;
    public GameObject bulletPos;
    public float bulletSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();

        timer += Time.deltaTime;

        if (fireTimer < timer && crosshair.gameObject.activeSelf == true)
        {
            if (Input.GetButtonDown("Fire1")) //��Ŭ��
            {
                if (cur_Bullet_Cnt > 0)
                {
                    ShotRayBullet();
                    cur_Bullet_Cnt--;
                }
                else
                {
                    Debug.Log("������ �ؾߵ˴ϴ�!!");
                }
                timer = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.R) && cur_Bullet_Cnt != reload_Bullet_Cnt && crosshair.gameObject.activeSelf == true) // ������
        {
            if (max_Bullet_Cnt > 0)
            {
                Reload();
            }
            else
            {
                Debug.Log("���� �� �� �ִ� �Ѿ��� �����ϴ�!!");
            }
        }
    }

    private void ShotRayBullet() // ray�� �̿��� �Ѿ� �߻�
    {
        
        List<GameObject> bul = new List<GameObject>();
        for(int i = 0; i < 5; i++)
        {
            bul.Add(Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation));
        }

        foreach(GameObject aaa in bul )
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            
            aaa.GetComponent<Rigidbody>().AddForce(aaa.transform.TransformDirection(new Vector3(x,y,60)) * Time.deltaTime * bulletSpeed);
            Destroy(aaa, 1f);
        }

       
    }

    void Reload()
    {
        if (max_Bullet_Cnt >= reload_Bullet_Cnt)
        {
            max_Bullet_Cnt -= reload_Bullet_Cnt - cur_Bullet_Cnt;
            cur_Bullet_Cnt = reload_Bullet_Cnt;
        }
        else
        {
            cur_Bullet_Cnt = max_Bullet_Cnt;
            max_Bullet_Cnt = 0;
        }
    }
}
