using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlayerFire : MonoBehaviour
{
    Vector2 createPoint = new Vector2(100, 100);
    public GameObject bulletFactory;
    public Transform firePosition;
    GameObject colEnemy;

    //총알 이펙트 오브젝트
    public GameObject bulletEffect;
    ParticleSystem ps;

    //총알 갯수
    int bullet_Cnt;
    int bullet_All;
    public Text bullet_Txt;
    Text bullet_cnt_txt;

    C_PlayerItem C_PlayerItem;

    //M_code
    public Collider melee;
    

    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        bullet_All = 50;
        bullet_Cnt = 20;
        bullet_cnt_txt = Instantiate(bullet_Txt, createPoint, Quaternion.identity, GameObject.Find("Canvas").transform);
        bullet_cnt_txt.text = (bullet_All + " / " + bullet_Cnt);

        C_PlayerItem = this.GetComponent<C_PlayerItem>();

    }

    // Update is called once per frame
    void Update()
    {
   
        /*if (Input.GetButtonDown("Fire1")) //좌클릭
        {
            if(C_PlayerItem.nowItem.name == "Gun") {
                ShotRayBullet();
            }
            if (C_PlayerItem.nowItem.name == "Pick")
            {
                if(meleeTimer > 2.0f)
                {
                    //M_code 광물 캐는 속도 
                    Mining();
                    melee.enabled = false;
                    meleeTimer = 0; 
                }
         
            }
        }*/

        if (C_PlayerItem.nowItem.name == "Gun")
        {
            if (Input.GetButtonDown("Fire1")) //좌클릭
            {
                ShotRayBullet();
            }
        }

        if (C_PlayerItem.nowItem.name == "Pick")
        {
            
                if (Input.GetButtonDown("Fire1")) //좌클릭
                {

                    Debug.Log("melee true");

                    melee.enabled = true;
                    
                }
                if(Input.GetButtonUp("Fire1")) 
                {
                    melee.enabled = false;
                }
        }


        if (Input.GetButtonDown("Fire2")) //우클릭
        {

        }

        if (Input.GetKeyDown(KeyCode.R)) //총 재장전
        {
            int bullt_Char = 20;
            if (bullet_All + bullet_Cnt <= 20 && bullet_All < 20) { bullt_Char = bullet_All; }

            if (bullet_All > 20)
            {
                bullet_All = bullet_All - bullt_Char + bullet_Cnt;
                bullet_Cnt = bullt_Char;
            }
            else if (bullet_All == 0)
            {
                Debug.Log("총알이 없습니다.");
            }
            else if (bullet_All < 20)
            {
                bullet_All = bullet_All - bullt_Char + bullet_Cnt;
                bullet_Cnt = bullt_Char;
            }

            Debug.Log("bullet_all : " + bullet_All + "  /  bulet_Cnt : " + bullet_Cnt);
            bullet_cnt_txt.text = (bullet_All + " / " + bullet_Cnt);
        }
    }


    private void ShotBigBullet() // 일반적인 총알 발사
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

    private void ShotRayBullet() // ray 를 이용한 총알 발사
    {
        if (bullet_Cnt > 0)
        {
            bullet_Cnt -= 1;
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                // 피격 이펙트
                GameObject bE = Instantiate(bulletEffect);
                bE.transform.position = hitInfo.point;
                ps = bE.GetComponent<ParticleSystem>();
                ps.Play();

                if (hitInfo.transform.gameObject.tag == "Enemy") //적일 경우 destroy
                {
                    //적 각각에게 데미지 구현 때문에 Enemy 부분으로 코드 옮김!
                    //GameObject.FindWithTag("Enemy").GetComponent<C_EnemyCtrl>().attack();
                    //Destroy(hitInfo.transform.gameObject);
                }
            }
            //Debug.Log("bullet_all : " + bullet_All + "  /  bulet_Cnt : " + bullet_Cnt);
            bullet_cnt_txt.text = (bullet_All + " / " + bullet_Cnt);
        }
    }

    private void Mining()
    {
        /*Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitInfo, 5))
        {
            Debug.Log(hitInfo.collider.tag);
            if(hitInfo.collider.tag == "ore")
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }*/

        // Debug.Log("Mining");
    }
}
