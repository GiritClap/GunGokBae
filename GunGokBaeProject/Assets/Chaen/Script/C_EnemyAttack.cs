using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
public class C_EnemyAttack : MonoBehaviour
{
    public float rotSpeed = 10 ;

    // AI
    public Transform target;
    NavMeshAgent nmAgent;

    private bool isAttack = false;

    private bool isDie = false;

    // �ִϸ��̼�
    private Animator ani;

    bool Taunt; // ���� ����ƺ�

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDie = transform.GetChild(0).GetComponent<C_EnemyCtrl>().isDie;
        if (isDie == true)
        {
            nmAgent.isStopped = true;
        }

        if (target == null) // Ÿ�� ���� �� ���ۺ��� ���� ���� => ���� �������� ���ƴٴϴ� �ŷ� ���� ����
        {

            ani.SetBool("Idle", false);
            isAttack = false;
            rotSpeed = 10;
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }

        else if (target != null) // Ÿ�� ������ Ÿ�� ����
        {
            rotSpeed = 10;
            float distance = Vector3.Distance(target.transform.position, this.transform.position);
            Vector3 dir = target.transform.position - this.transform.position;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
            nmAgent.SetDestination(target.position);

            if (distance >= 4)
            {
                ani.SetBool("Idle", false);
            }

            else if (distance <= 4.0f)
            {
                if (isAttack == false)
                {
                    ani.SetBool("Idle", true);
                    StartCoroutine(Attack());
                }
            }
        }
    }

    // ����
    IEnumerator Attack()
    {
        nmAgent.isStopped = true;
        isAttack = true;
        ani.SetBool("Attack", true);    
        yield return new WaitForSeconds(0.5f);
        if(target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<C_PlayerStatus>().Attack(5);
        }
        ani.SetBool("Attack", false);
        yield return new WaitForSeconds(3.0f);
        isAttack = false;
        nmAgent.isStopped = false;
    }



    private void OnTriggerStay(Collider other) // Find ���� �ذ��Ϸ��� ���� ������ ��� ���� �� Ÿ�� ����
    {
        // �� ����
       if(other.tag == "Taunt") { // ���� ����ƺ� �켱���� Ÿ���� �ǰ� ��
            target = other.gameObject.transform;
       }

        else if (other.tag == "Player" && target == null) // �̹� Ÿ���� ���� ��쿣 �۵� ���ϰ� Ÿ���� ���� ���� �÷��̾� Ÿ������ ����
        {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) // ���� ���� ������ ������ �� Ÿ�� ����
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }


}
