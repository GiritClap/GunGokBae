using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Sniper : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    float max_Bullet_Cnt = 15; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 4; // ���� �� �� �ִ� �Ѿ� ��
    public float damage = 0; // ������
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
        if (crosshair == null)
        {
            crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        }

        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.tag = "Sniper";
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

        GameObject bul = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        bul.GetComponentInChildren<Rigidbody>().AddForce(bul.transform.TransformDirection(Vector3.forward) * Time.deltaTime * bulletSpeed * 10000f);
        Destroy(bul, 5f);

    }

    void Reload()
    {
        if (max_Bullet_Cnt >= reload_Bullet_Cnt)
        {
            max_Bullet_Cnt -= reload_Bullet_Cnt;
            cur_Bullet_Cnt = reload_Bullet_Cnt;
        }
        else
        {
            cur_Bullet_Cnt = max_Bullet_Cnt;
            max_Bullet_Cnt = 0;
        }
    }

    public void ResetToLevel1()
    {
        damage = 10;
        max_Bullet_Cnt = 15;
    }

    public void UpdateDamage(float a)
    {
        damage += a;
    }

    public void UpgradeMaxBulletCnt(float a)
    {
        max_Bullet_Cnt += a;
    }

    public float CurrentDamage()
    {
        return damage;
    }

    public float CurrentMaxBulletCnt()
    {
        return max_Bullet_Cnt;
    }
}
