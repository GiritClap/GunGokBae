using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EnemyCtrl : MonoBehaviour
{
    public Image hpBar;
    public int curHp;
    public int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f , 1f);

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
            Attack();
        }

        if(other.tag == "rocket_attack") // 특수총 - 로켓
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
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp/ (float)maxHp, 1f, 1f); //HP바 체력 동기화
        if(curHp <= 0)
        {
            Destroy(transform.parent.gameObject); // 현재 Enemy 자식 오브젝트라서 부모 오브젝트 삭제로 변경
        }
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
