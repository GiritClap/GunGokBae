using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class C_DragonAttack : MonoBehaviour
{
    public float rotSpeed = 10;

    // AI
    public Transform target;
    NavMeshAgent nmAgent;

    // 공격
    public GameObject bulletFactory;
    public Transform firePosition;

    private bool isAttack = false;

    // 애니메이션
    private Animator ani;

    bool Taunt; // 도발 허수아비

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) // 타겟 없을 시 빙글빙글 돌고 있음 => 추후 일정범위 돌아다니는 거로 수정 예정
        {
            rotSpeed = 10;
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }

        else if (target != null) // 타겟 생성시 타겟 따라감
        {
            float distance = Vector3.Distance(target.transform.position, this.transform.position);
            transform.LookAt(target);
            nmAgent.SetDestination(target.position);

            if (distance <= 10.0f)
            {
                nmAgent.Stop();
                if (isAttack == false)
                {
                    ani.SetBool("Idle", true);
                    StartCoroutine(Attack());
                }
            }
        }
    }

    // 공격
    IEnumerator Attack()
    {
        isAttack = true;
        ani.SetBool("Attack", true);
        yield return new WaitForSeconds(0.5f);
        ShotBullet(); // 총알 발사
        ani.SetBool("Attack", false);
        yield return new WaitForSeconds(3.0f);
        isAttack = false;
    }



    private void OnTriggerStay(Collider other) // Find 단점 해결하려고 일정 영역에 들어 왔을 때 타겟 지정
    {
        // 적 추적
        if (other.tag == "Taunt")
        { // 도발 허수아비가 우선으로 타겟이 되게 함
            target = other.gameObject.transform;
        }

        else if (other.tag == "Player" && target == null) // 이미 타겟이 있을 경우엔 작동 안하고 타겟이 없을 때만 플레이어 타겟으로 지정
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


    private void ShotBullet() // 일반적인 총알 발사
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

}
