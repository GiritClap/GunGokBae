using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_OriginalGun : MonoBehaviour
{
    public float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    public float max_Bullet_Cnt = 70; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 10; // ���� �� �� �ִ� �Ѿ� ��
    public float damage = 0; // �� ������
    public GameObject bulletEffect;
    ParticleSystem ps;
    public Text bulletCntText;

    public float fireTimer = 0; // �߻�ӵ�
    float timer = 0;

    public Image crosshair;

    M_RaycastWeapon weapon;

    public AudioClip pistolShotClip;
    public AudioClip reloadClip;


    // ���� �浹 �ݶ��̴�
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
            if (Input.GetButtonDown("Fire1")) //��Ŭ��
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
                    Debug.Log("������ �ؾߵ˴ϴ�!!");
                }
                timer = 0;
            }
        }
        if(Input.GetButtonUp("Fire1"))
        {
            weapon.StopPistolFiring();
            raycoll.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && cur_Bullet_Cnt != reload_Bullet_Cnt && crosshair.gameObject.activeSelf == true) // ������
        {
            if (max_Bullet_Cnt > 0)
            {
                M_SoundManager.instance.SFXPlay("reload", reloadClip);

                Reload();
            }
            else
            {
                Debug.Log("���� �� �� �ִ� �Ѿ��� �����ϴ�!!");
            }
        }
    }

    /*private void ShotRayBullet() // ray�� �̿��� �Ѿ� �߻�
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
