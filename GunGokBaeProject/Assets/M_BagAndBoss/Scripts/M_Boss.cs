using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class M_Boss : MonoBehaviour
{
    public NavMeshAgent agent;

    GameObject[] player;
    int randPlayer;

    //whatisground ���̾���� ������
    public LayerMask whatIsGround, whatIsPlayer;

    public Collider[] meleeWeapon;

    //����1,2�� ����� ������
    public GameObject pattern01;
    public GameObject pattern02;

    public GameObject pattern03;

    //���� Ÿ�̸�
    float pTimer;
    bool isP01;
    bool isP02;
    bool isP03;
    bool isP03_1;

    //���� ü��
    public Slider bossHp;
    float maxBossHp = 1200f;
    public float currentBossHp = 1200f;
    public Text currentBossHpTxt;


    //��Ʈ��
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //����
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //����
    // ���ϸ��� �þ߹����� ���ݹ��� �к�
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator anim;

    public AudioClip[] clips; // 0 = 기본공격, 1 = 패턴1 땅찍기, 2 = 패턴2 땅찍기, 3 = 패턴2 운석떨어지기, 4 = 패턴3 불뿜기

    bool isDie = false;

    public ParticleSystem dieEffect;
    public GameObject dieEffectPos;

    M_OriginalGun pistol;
    M_Machinegun machinegun;
    M_Shotgun shotgun;
    M_Sniper sniper;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        randPlayer = 0;
        FindPlayer();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bossHp.value = currentBossHp / maxBossHp;
        currentBossHpTxt.text = currentBossHp.ToString("N0") + " / " + maxBossHp.ToString("N0") + " HP";
        
        if(isDie == false)
        {
            if (player[0] == null)
            {
                FindPlayer();
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
                //������ �þ�, ���ݰ��ɹ���
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            }

            if (isP03_1 == true)
            {
                Debug.Log("��");
                transform.Rotate(Vector3.up * Time.deltaTime * 180);
            }

            /*if(pTimer > 7.0f)
            {
                isP01 = true;
                //������ �þ�, ���ݰ��ɹ���
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange + 1000f, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange + 1000f, whatIsPlayer);
                pTimer = 0f;
            }
            else
            {
                isP01 = false;
                //������ �þ�, ���ݰ��ɹ���
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

        }




    }


    #region 데미지

    private void K_Damage()
    {

    }

    #endregion
    private void Patroling()
    {
        anim.SetBool("IsWalking", true);

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
            Debug.Log("�ν�");
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        randPlayer = Random.Range(0, 3);
                //  0 -> randPlayer로 수정바람

        agent.SetDestination(player[0].transform.position);
        anim.SetBool("IsWalking", true);

    }
    private void AttackPlayer()
    {
        anim.SetBool("IsWalking", false);

        //�ڱ� ��ġ�� ����
        //agent.SetDestination(transform.position);
        agent.ResetPath();
        //  0 -> randPlayer로 수정바람
        Vector3 targetPos = new Vector3(player[0].transform.position.x, transform.position.y, player[0].transform.position.z);

        if (!isP03_1)
        {
            transform.LookAt(targetPos);
        }

        if (!alreadyAttacked)
        {
            //���� �ڵ� �ۼ�
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
        anim.SetTrigger("DoMeleeAttack");
        M_SoundManager.instance.SFXPlay("attack", clips[0]);

        meleeWeapon[0].enabled = true;
        meleeWeapon[1].enabled = true;
        yield return new WaitForSeconds(0.5f);
        meleeWeapon[0].enabled = false;
        meleeWeapon[1].enabled = false;
    }

    // �÷��̾� �߹ؿ��� ����
    IEnumerator Pattern01()
    {
        anim.SetTrigger("DoPattern01");
        M_SoundManager.instance.SFXPlay("pattern01_landAttack", clips[1]);

        isP01 = false;
        for(int i = 0; i< player.Length; i++)
        {
            GameObject p01 = Instantiate(pattern01, player[i].transform.position + new Vector3(0, -0.05f, 0), player[i].transform.rotation);
            yield return new WaitForSeconds(5f);
            Destroy(p01);
        }
        

    }

    // ��ü�� �߹� �ð��� ��������
    IEnumerator Pattern02()
    {
        anim.SetTrigger("DoPattern02");
        M_SoundManager.instance.SFXPlay("pattern02_landAttack", clips[2]);

        isP02 = false;
        for(int i = 0; i < player.Length; i++)
        {
            M_SoundManager.instance.SFXPlay("pattern02_Meteor", clips[3]);
            GameObject p01 = Instantiate(pattern02, player[i].transform.position + new Vector3(0, -0.05f, 0), player[i].transform.rotation);
            yield return new WaitForSeconds(2f);
            Destroy(p01);

            M_SoundManager.instance.SFXPlay("pattern02_Meteor", clips[3]);
            GameObject p02 = Instantiate(pattern02, player[i].transform.position + new Vector3(0, -0.05f, 0), player[i].transform.rotation);
            yield return new WaitForSeconds(2f);
            Destroy(p02);

            M_SoundManager.instance.SFXPlay("pattern02_Meteor", clips[3]);
            GameObject p03 = Instantiate(pattern02, player[i].transform.position + new Vector3(0, -0.05f, 0), player[i].transform.rotation);
            yield return new WaitForSeconds(2f);
            Destroy(p03);

            M_SoundManager.instance.SFXPlay("pattern02_Meteor", clips[3]);
            GameObject p04 = Instantiate(pattern02, player[i].transform.position + new Vector3(0, -0.05f, 0), player[i].transform.rotation);
            yield return new WaitForSeconds(2f);
            Destroy(p04);
        }
        

    }

    //���ڸ� �ѹ��� ���鼭 ����(���ڸ��귡������ ����)
    IEnumerator Pattern03()
    {
        anim.SetTrigger("DoPattern03");
        M_SoundManager.instance.SFXPlay("pattern03_FireBreathe", clips[4]);

        isP03 = false;
        pattern03.SetActive(true);
        yield return new WaitForSeconds(3f);
        isP03_1 = false;
        pattern03.SetActive(false);

    }

    IEnumerator Damaged()
    {
        agent.SetDestination(transform.position);
        anim.SetBool("IsDamaged", true);
        yield return new WaitForSeconds(0.1f);
        agent.SetDestination(player[0].transform.position);
        anim.SetBool("IsDamaged", false);
    }

    IEnumerator Die()
    {
        isDie = true;
        agent.SetDestination(transform.position);
        anim.SetTrigger("DoDie");
        GameObject effect = Instantiate(dieEffect.gameObject, dieEffectPos.transform.position, Quaternion.identity);
        
        Destroy(effect, 3f);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);

    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        pistol = GameObject.FindWithTag("OriginalGun").GetComponent<M_OriginalGun>();
        machinegun = GameObject.FindWithTag("OriginalGun").GetComponent<M_Machinegun>();
        shotgun = GameObject.FindWithTag("OriginalGun").GetComponent<M_Shotgun>();
        sniper = GameObject.FindWithTag("OriginalGun").GetComponent<M_Sniper>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player_attack")
        {
            currentBossHp -= pistol.CurrentDamage();
            if(currentBossHp > 0)
            {
                StartCoroutine("Damaged");

            }
            else if(currentBossHp <= 0)
            {
                StartCoroutine("Die");
            }
        }

        if(other.gameObject.tag == "machinegunAttack")
        {
            currentBossHp -= machinegun.CurrentDamage();
            if (currentBossHp > 0)
            {
                StartCoroutine("Damaged");

            }
            else if (currentBossHp <= 0)
            {
                StartCoroutine("Die");
            }
        }

        if (other.gameObject.tag == "shotgunAttack")
        {
            currentBossHp -= shotgun.CurrentDamage();
            if (currentBossHp > 0)
            {
                StartCoroutine("Damaged");

            }
            else if (currentBossHp <= 0)
            {
                StartCoroutine("Die");
            }
        }

        if (other.gameObject.tag == "sniperAttack")
        {
            currentBossHp -= sniper.CurrentDamage();
            if (currentBossHp > 0)
            {
                StartCoroutine("Damaged");

            }
            else if (currentBossHp <= 0)
            {
                StartCoroutine("Die");
            }
        }

    }
}
