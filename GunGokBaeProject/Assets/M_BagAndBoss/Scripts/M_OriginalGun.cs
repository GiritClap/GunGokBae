using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_OriginalGun : MonoBehaviour
{
    public float cur_Bullet_Cnt = 0; // 현재 총알수
    public float max_Bullet_Cnt = 70; // 총 총알수
    float reload_Bullet_Cnt = 10; // 장전 할 수 있는 총알 수
    public float damage = 0; // 총 데미지
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // 발사속도
    float timer = 0;

    public Image crosshair;

    M_RaycastWeapon weapon;

    public AudioClip pistolShotClip;
    public AudioClip reloadClip;


    // 레이 충돌 콜라이더
    public Collider raycoll;

    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();
        if (crosshair == null)
        {
            crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        }
        damage = 3f;
        weapon = GetComponent<M_RaycastWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.tag = "OriginalGun";
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();

        timer += Time.deltaTime;

        if (fireTimer < timer && crosshair.gameObject.activeSelf == true)
        {
            if (Input.GetButtonDown("Fire1")) //좌클릭
            {
                if (cur_Bullet_Cnt > 0)
                {
                    weapon.StartPistolFiring();

                    M_SoundManager.instance.SFXPlay("pistol", pistolShotClip);

                    //ShotRayBullet();
                    cur_Bullet_Cnt--;

                    raycoll.enabled = true;
                }
                else
                {
                    Debug.Log("재장전 해야됩니다!!");
                }
                timer = 0;
            }
        }
        if(Input.GetButtonUp("Fire1"))
        {
            weapon.StopPistolFiring();
            raycoll.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && cur_Bullet_Cnt != reload_Bullet_Cnt && crosshair.gameObject.activeSelf == true) // 재장전
        {
            if (max_Bullet_Cnt > 0)
            {
                M_SoundManager.instance.SFXPlay("reload", reloadClip);

                Reload();
            }
            else
            {
                Debug.Log("장전 할 수 있는 총알이 없습니다!!");
            }
        }
    }

    /*private void ShotRayBullet() // ray를 이용한 총알 발사
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        RaycastHit hitInfo;
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("whatIsPlayer"));  // Everything에서 Player 레이어만 제외하고 충돌 체크함

        if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
        {
            // 피격 이펙트
            GameObject bE = Instantiate(bulletEffect);
            bE.transform.position = hitInfo.point;
            ps = bE.GetComponent<ParticleSystem>();
            ps.Play();
        }
    }*/
   


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

    public void ResetToLevel1()
    {
        damage = 3;
        max_Bullet_Cnt = 70;
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
