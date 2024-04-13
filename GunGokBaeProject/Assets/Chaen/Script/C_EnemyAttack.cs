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
        if (target == null) // Ÿ�� ���� �� ���ۺ��� ���� ���� => ���� �������� ���ƴٴϴ� �ŷ� ���� ����
        {
            rotSpeed = 10 ;
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }

        else if (target != null) // Ÿ�� ������ Ÿ�� ����
        {
            nmAgent.SetDestination(target.position);
        }
    }
    private void OnTriggerStay(Collider other) // Find ���� �ذ��Ϸ��� ���� ������ ��� ���� �� Ÿ�� ����
    {
        // �� ����
        if (other.tag == "Player")
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
