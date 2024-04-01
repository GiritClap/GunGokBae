using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class M_Shotgun : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // 현재 총알수
    float max_Bullet_Cnt = 30; // 총 총알수
    float reload_Bullet_Cnt = 7; // 장전 할 수 있는 총알 수
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // 발사속도

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

        if (fireTimer > 3f && crosshair.gameObject.activeSelf == true)
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
                fireTimer = 0;
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
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        //RaycastHit hitInfo;
        /*if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            // 피격 이펙트
            GameObject bE = Instantiate(bulletEffect);
            bE.transform.position = hitInfo.point;
            ps = bE.GetComponent<ParticleSystem>();
            ps.Play();
        }*/

        RaycastHit hitInfo;
        List<Ray> rays = new List<Ray>();
        for (int i = 0; i < 6; i++)
        {
            int x = Random.Range(-30, 30);
            int y = Random.Range(-30, 30);
            rays.Add(Camera.main.ViewportPointToRay(new Vector2(x, y)));
        }

        foreach (Ray ray in rays)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject bE = Instantiate(bulletEffect);
                bE.transform.position = hitInfo.point;
                ps = bE.GetComponent<ParticleSystem>();
                ps.Play();
            }
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
