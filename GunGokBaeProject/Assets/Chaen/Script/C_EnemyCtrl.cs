using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class C_EnemyCtrl : MonoBehaviour
{
    public Image hpBar;
    public float rotSpeed;
    public int curHp;
    public int maxHp;

    // AI
    public Transform target;
    NavMeshAgent nmAgent;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f , 1f);
        nmAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 타게팅 방식 : 씬 내에서 player태그 가진사람 -> 문제점 : 가장 먼저 접속한 사람한테 고정
        // 추후에 변경
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        nmAgent.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        // 기본 총 공격
        if (other.tag == "player_attack")
        {
            Debug.Log(other.gameObject.name + " 충돌");
            attack();
        }

        // 힐 총
        else if(other.tag == "gun_heal")
        {
            Debug.Log(other.gameObject.name + " 힐");
            heal();
        }
    }

    public void attack()
    {
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp/ (float)maxHp, 1f, 1f);
        if(curHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void heal()
    {
        curHp += 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }

}
