using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Sniper : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // 현재 총알수
    float max_Bullet_Cnt = 15; // 총 총알수
    float reload_Bullet_Cnt = 4; // 장전 할 수 있는 총알 수
    public float damage = 0; // 데미지
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // 발사속도
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
            if (Input.GetButtonDown("Fire1")) //좌클릭
            {
                if (cur_Bullet_Cnt > 0)
                {
                    ShotRayBullet();
                    cur_Bullet_Cnt--;
                }
                else
                {
                    Debug.Log("재장전 해야됩니다!!");
                }
                timer = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.R) && cur_Bullet_Cnt != reload_Bullet_Cnt && crosshair.gameObject.activeSelf == true) // 재장전
        {
            if (max_Bullet_Cnt > 0)
            {
                Reload();
            }
            else
            {
                Debug.Log("장전 할 수 있는 총알이 없습니다!!");
            }
        }
    }

    private void ShotRayBullet() // ray를 이용한 총알 발사
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
