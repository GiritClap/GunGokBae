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

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) // Ÿ�� ���� �� ���ۺ��� ���� ���� => ���� �������� ���ƴٴϴ� �ŷ� ���� ����
        {
            rotSpeed = 10;
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }

        else if (target != null) // Ÿ�� ������ Ÿ�� ����
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

    // ����
    IEnumerator Attack()
    {
        isAttack = true;
        ani.SetBool("Attack", true);
        yield return new WaitForSeconds(0.5f);
        ShotBullet(); // �Ѿ� �߻�
        ani.SetBool("Attack", false);
        yield return new WaitForSeconds(3.0f);
        isAttack = false;
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
