using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Machinegun : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    float max_Bullet_Cnt = 150; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 30; // ���� �� �� �ִ� �Ѿ� ��
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // �߻�ӵ�
    float timer = 0;

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

        timer += Time.deltaTime;

        if (fireTimer < timer && crosshair.gameObject.activeSelf == true)
        {
            if (Input.GetButton("Fire1")) //��Ŭ��
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
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        RaycastHit hitInfo;
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("whatIsPlayer"));  // Everything���� Player ���̾ �����ϰ� �浹 üũ��

        if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
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
        if (max_Bullet_Cnt >= reload_Bullet_Cnt)
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