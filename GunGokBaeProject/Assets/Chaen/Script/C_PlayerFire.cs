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

    //�Ѿ� ����Ʈ ������Ʈ
    public GameObject bulletEffect;
    ParticleSystem ps;

    //�Ѿ� ����
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
   
        /*if (Input.GetButtonDown("Fire1")) //��Ŭ��
        {
            if(C_PlayerItem.nowItem.name == "Gun") {
                ShotRayBullet();
            }
            if (C_PlayerItem.nowItem.name == "Pick")
            {
                if(meleeTimer > 2.0f)
                {
                    //M_code ���� ĳ�� �ӵ� 
                    Mining();
                    melee.enabled = false;
                    meleeTimer = 0; 
                }
         
            }
        }*/

        if (C_PlayerItem.nowItem.name == "Gun")
        {
            if (Input.GetButtonDown("Fire1")) //��Ŭ��
            {
                ShotRayBullet();
            }
        }

        if (C_PlayerItem.nowItem.name == "Pick")
        {
            
                if (Input.GetButtonDown("Fire1")) //��Ŭ��
                {

                    Debug.Log("melee true");

                    melee.enabled = true;
                    
                }
                if(Input.GetButtonUp("Fire1")) 
                {
                    melee.enabled = false;
                }
        }


        if (Input.GetButtonDown("Fire2")) //��Ŭ��
        {

        }

        if (Input.GetKeyDown(KeyCode.R)) //�� ������
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
                Debug.Log("�Ѿ��� �����ϴ�.");
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


    private void ShotBigBullet() // �Ϲ����� �Ѿ� �߻�
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

    private void ShotRayBullet() // ray �� �̿��� �Ѿ� �߻�
    {
        if (bullet_Cnt > 0)
        {
            bullet_Cnt -= 1;
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                // �ǰ� ����Ʈ
                GameObject bE = Instantiate(bulletEffect);
                bE.transform.position = hitInfo.point;
                ps = bE.GetComponent<ParticleSystem>();
                ps.Play();

                if (hitInfo.transform.gameObject.tag == "Enemy") //���� ��� destroy
                {
                    //�� �������� ������ ���� ������ Enemy �κ����� �ڵ� �ű�!
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
