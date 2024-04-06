using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class M_Boss : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    //whatisground 레이어에서만 움직임
    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject meleeWeapon;

    //패턴1,2에 사용할 프리펩
    public GameObject pattern01;
    public GameObject pattern02;

    public GameObject pattern03;

    //패턴 타이머
    float pTimer;
    bool isP01;
    bool isP02;
    bool isP03;
    bool isP03_1;

    //보스 체력
    public Slider bossHp;
    float maxBossHp = 100f;
    public float currentBossHp = 100f;


    //패트롤
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //공격
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //상태
    // 패턴마다 시야범위와 공격범위 분별
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.FindWithTag("whatIsPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("whatIsPlayer").transform;
        }

        pTimer += Time.deltaTime * 1f;
        if (pTimer > 10.0f)
        {
            RandomPattern();
            pTimer = 0f;
        }

        if (isP01 || isP02 || isP03)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange + 1000f, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange + 1000f, whatIsPlayer);
        }
        else
        {
            //보스몹 시야, 공격가능범위
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        }

        if (isP03_1 == true)
        {
            Debug.Log("슛");
            transform.Rotate(Vector3.up * Time.deltaTime * 72);
        }

        /*if(pTimer > 7.0f)
        {
            isP01 = true;
            //보스몹 시야, 공격가능범위
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange + 1000f, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange + 1000f, whatIsPlayer);
            pTimer = 0f;
        }
        else
        {
            isP01 = false;
            //보스몹 시야, 공격가능범위
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        }
   */

        if (!playerInSightRange && !playerInAttackRange && !alreadyAttacked)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange && !alreadyAttacked)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }



        bossHp.value = currentBossHp / maxBossHp;
        if (currentBossHp <= 0f)
        {
            Destroy(this);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        Debug.Log(Physics.Raycast(walkPoint, -transform.up, 12f, whatIsGround));
        Debug.DrawRay(walkPoint, -transform.up * 12f, Color.red);
        if (Physics.Raycast(walkPoint, -transform.up, 12f, whatIsGround))
        {
            Debug.Log("인식");
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //자기 위치에 서기
        //agent.SetDestination(transform.position);
        agent.ResetPath();
        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);

        if (!isP03_1)
        {
            transform.LookAt(targetPos);
        }

        if (!alreadyAttacked)
        {
            //공격 코드 작성
            if (isP01)
            {
                StartCoroutine("Pattern01");
            }
            else if (isP02)
            {
                StartCoroutine("Pattern02");
            }
            else if (isP03)
            {
                StartCoroutine("Pattern03");
            }
            else
            {
                StartCoroutine("MeleeAttack");
            }

            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 3);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void RandomPattern()
    {
        int aaa = Random.Range(0, 3);
        if (aaa == 0)
        {
            isP01 = true;
        }
        else if (aaa == 1)
        {
            isP02 = true;

        }
        else
        {
            isP03 = true;
            isP03_1 = true;
        }
    }

    IEnumerator MeleeAttack()
    {
        meleeWeapon.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        meleeWeapon.SetActive(false);
    }

    // 플레이어 발밑에서 공격
    IEnumerator Pattern01()
    {
        isP01 = false;
        GameObject p01 = Instantiate(pattern01, player.position + new Vector3(0, -0.8f, 0), player.rotation);
        yield return new WaitForSeconds(5f);
        Destroy(p01);

    }

    // 전체맵 발밑 시간차 랜덤공격
    IEnumerator Pattern02()
    {
        isP02 = false;
        GameObject p01 = Instantiate(pattern02, player.position + new Vector3(0, -0.8f, 0), player.rotation);
        yield return new WaitForSeconds(1.3f);
        Destroy(p01);
        GameObject p02 = Instantiate(pattern02, player.position + new Vector3(0, -0.8f, 0), player.rotation);
        yield return new WaitForSeconds(1.3f);
        Destroy(p02);
        GameObject p03 = Instantiate(pattern02, player.position + new Vector3(0, -0.8f, 0), player.rotation);
        yield return new WaitForSeconds(1.3f);
        Destroy(p03);
        GameObject p04 = Instantiate(pattern02, player.position + new Vector3(0, -0.8f, 0), player.rotation);
        yield return new WaitForSeconds(1.3f);
        Destroy(p04);

    }

    //제자리 한바퀴 돌면서 공격(리자몽브래스같은 느낌)
    IEnumerator Pattern03()
    {
        isP03 = false;
        pattern03.SetActive(true);
        yield return new WaitForSeconds(3f);
        isP03_1 = false;
        pattern03.SetActive(false);

    }
}
