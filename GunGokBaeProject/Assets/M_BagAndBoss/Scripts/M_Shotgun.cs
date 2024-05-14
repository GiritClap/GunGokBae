using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Shotgun : MonoBehaviour
{
    float cur_Bullet_Cnt = 0; // ���� �Ѿ˼�
    float max_Bullet_Cnt = 30; // �� �Ѿ˼�
    float reload_Bullet_Cnt = 7; // ���� �� �� �ִ� �Ѿ� ��
    public float damage = 0; // ������
 
    public Text bulletCntText;

    public float fireTimer = 0; // �߻�ӵ�
    float timer = 0;

    public Image crosshair;

    public GameObject bullet;
    public GameObject bulletPos;
    public float bulletSpeed = 30f;


    public AudioClip shotgunShotClip;
    public AudioClip reloadClip;



    public ParticleSystem shotgunMuzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();
        if(crosshair == null)
        {
            crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        }

        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.tag = "Shotgun";
        bulletCntText.text = cur_Bullet_Cnt.ToString() + " / " + max_Bullet_Cnt.ToString();

        timer += Time.deltaTime;

        if (fireTimer < timer && crosshair.gameObject.activeSelf == true)
        {
            if (Input.GetButtonDown("Fire1")) //��Ŭ��
            {
                if (cur_Bullet_Cnt > 0)
                {
                    ShotRayBullet();
                    M_SoundManager.instance.SFXPlay("shotgun", shotgunShotClip);
                    shotgunMuzzleFlash.Play();
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
                M_SoundManager.instance.SFXPlay("shotgunReload", reloadClip);

                Reload();
            }
            else
            {
                Debug.Log("���� �� �� �ִ� �Ѿ��� �����ϴ�!!");
            }
        }
    }

    private void ShotRayBullet() 
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

    public void ResetToLevel1()
    {
        damage = 1;
        max_Bullet_Cnt = 30;
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
