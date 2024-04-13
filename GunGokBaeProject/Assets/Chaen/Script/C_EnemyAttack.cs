using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class C_EnemyAttack : MonoBehaviour
{
    public float rotSpeed = 10 ;

    // AI
    public Transform target;
    NavMeshAgent nmAgent;


    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) // 타겟 없을 시 빙글빙글 돌고 있음 => 추후 일정범위 돌아다니는 거로 수정 예정
        {
            rotSpeed = 10 ;
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }

        else if (target != null) // 타겟 생성시 타겟 따라감
        {
            nmAgent.SetDestination(target.position);
        }
    }
    private void OnTriggerStay(Collider other) // Find 단점 해결하려고 일정 영역에 들어 왔을 때 타겟 지정
    {
        // 적 추적
        if (other.tag == "Player")
        {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) // 일정 영역 밖으로 나갔을 때 타겟 해제
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }

}
