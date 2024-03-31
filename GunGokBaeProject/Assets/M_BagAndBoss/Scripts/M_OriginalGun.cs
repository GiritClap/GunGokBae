using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_OriginalGun : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    float max_Bullet_Cnt = 80; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 20; // ���� �� �� �ִ� �Ѿ� ��
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // �߻�ӵ�

    public Image crosshair;


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

        fireTimer += Time.deltaTime;

        if(fireTimer > 1.5f && crosshair.gameObject.activeSelf == true)
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
                fireTimer = 0;
            }
        }
       

        if (Input.GetKeyDown(KeyCode.R) && cur_Bullet_Cnt != reload_Bullet_Cnt && crosshair.gameObject.activeSelf == true) // ������
        {
            if(max_Bullet_Cnt > 0)
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
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                // �ǰ� ����Ʈ
                GameObject bE = Instantiate(bulletEffect);
                bE.transform.position = hitInfo.point;
                ps = bE.GetComponent<ParticleSystem>();
                ps.Play();
            }        
    }

    void Reload()
    {
        if(max_Bullet_Cnt >= reload_Bullet_Cnt)
        {
            cur_Bullet_Cnt = reload_Bullet_Cnt;
            max_Bullet_Cnt -= reload_Bullet_Cnt;
        }
        else
        {
            cur_Bullet_Cnt = max_Bullet_Cnt;
            max_Bullet_Cnt = 0;
        }
    }
}
