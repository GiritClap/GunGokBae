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

    // ����
    public GameObject bulletFactory;
    public Transform firePosition;

    private bool isAttack = false;

    // �ִϸ��̼�
    private Animator ani;

    bool Taunt; // ���� ����ƺ�

    bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isDie = transform.GetChild(0).GetComponent<C_EnemyCtrl>().isDie;
        if(isDie == true)
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

            ani.SetBool("Idle", false);
            rotSpeed = 10;
            float distance = Vector3.Distance(target.transform.position, this.transform.position);
            Vector3 dir = target.transform.position - this.transform.position;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
            nmAgent.SetDestination(target.position);

            if (distance <= 10.0f)
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
        ShotBullet(); // �Ѿ� �߻�
        ani.SetBool("Attack", false);
        yield return new WaitForSeconds(3.0f);
        isAttack = false;
        nmAgent.isStopped = false;
    }



    private void OnTriggerStay(Collider other) // Find ���� �ذ��Ϸ��� ���� ������ ��� ���� �� Ÿ�� ����
    {
        // �� ����
        if (other.tag == "Taunt")
        { // ���� ����ƺ� �켱���� Ÿ���� �ǰ� ��
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


    private void ShotBullet() // �Ϲ����� �Ѿ� �߻�
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePosition.position;
        bullet.transform.forward = firePosition.forward;
    }

}
