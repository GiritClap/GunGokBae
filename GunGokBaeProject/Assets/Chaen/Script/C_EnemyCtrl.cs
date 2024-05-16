using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class C_EnemyCtrl : MonoBehaviour
{
    
    public Image hpBar;
    public int curHp;
    public int maxHp;

    // 애니메이션
    private Animator ani;

    private bool isHit = false;

    public bool isDie = false;

    M_OriginalGun pistol;
    M_Machinegun machinegun;
    M_Shotgun shotgun;
    M_Sniper sniper;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f , 1f);

        ani = transform.GetComponentInParent<Animator>();

        pistol = GameObject.FindWithTag("OriginalGun").GetComponent<M_OriginalGun>();
        machinegun = GameObject.FindWithTag("OriginalGun").GetComponent<M_Machinegun>();
        shotgun = GameObject.FindWithTag("OriginalGun").GetComponent<M_Shotgun>();
        sniper = GameObject.FindWithTag("OriginalGun").GetComponent<M_Sniper>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other) // 네비매쉬 트리거랑 겹쳐서 따로 빼냈음
    {
        // 기본 총 공격
        if (other.tag == "player_attack") // 기본 총
        {
            Debug.Log(other.gameObject.name + " 충돌");
            if (isHit == false)
            {
                StartCoroutine(Hit((int)pistol.CurrentDamage()));
            }
        }


        if (other.tag == "machinegunAttack") // 머신건
        {
            Debug.Log(other.gameObject.name + " 충돌");
            if (isHit == false)
            {
                StartCoroutine(Hit((int)machinegun.CurrentDamage()));
            }
        }
        if (other.tag == "shotgunAttack") // 샷건
        {
            Debug.Log(other.gameObject.name + " 충돌");
            if (isHit == false)
            {
                StartCoroutine(Hit((int)shotgun.CurrentDamage()));
            }
        }
        if (other.tag == "sniperAttack") // 스나이퍼
        {
            Debug.Log(other.gameObject.name + " 충돌");
            if (isHit == false)
            {
                StartCoroutine(Hit((int)sniper.CurrentDamage()));
            }
        }






        if (other.tag == "rocket_attack") // 특수총 - 로켓
        {
            Debug.Log(other.gameObject.name + " 충돌");
            RocketAttack();
        }

        // 힐 총
        if(other.tag == "gun_heal")
        {
            Debug.Log(other.gameObject.name + " 힐");
            Heal();
        }
    }

    public void Attack()
    {
        ani.SetBool("attack", true);
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp/ (float)maxHp, 1f, 1f); //HP바 체력 동기화
        if(curHp <= 0)
        {
            Destroy(transform.parent.gameObject); // 현재 Enemy 자식 오브젝트라서 부모 오브젝트 삭제로 변경
        }

        
    }

    IEnumerator Hit(int dmg) // 공격 당했을 때
    {
        isHit = true;
        curHp -= dmg;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f); //HP바 체력 동기화

        if (curHp <= 0)
        {
            isDie = true;
            ani.SetBool("Die", true);  // 체력 0이면 죽음 애니메이션 재생 
            transform.GetComponentInParent<CapsuleCollider>().enabled = false; // 콜라이더 해제
            yield return new WaitForSeconds(2.0f);
            Destroy(transform.parent.gameObject); // 현재 Enemy 자식 오브젝트라서 부모 오브젝트 삭제로 변경
        }

        else
        {
            ani.SetBool("Hit", true); // Hit 애니메이션 재생
            yield return new WaitForSeconds(0.2f);
            ani.SetBool("Hit", false);
        }

        isHit = false;
    }

    public void RocketAttack()
    {
        curHp -= 100;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
        if (curHp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void Heal()
    {
        curHp += 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }

}
