using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �ݴ� ��ũ��Ʈ �׳� ���Z ���� ������
//�̰� �Ⱦ���

public class ActionController : MonoBehaviour   
{
    [SerializeField]
    private float range; //�ִ� ���� ��Ÿ�?
    private bool pickupActivated = false; //���� ������ �� true
    private RaycastHit hitInfo; //�浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask; //������ ���̾�� �����ϵ��� ���̾� ����ũ ����


    //private Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TryAction()
    {
        CheckItem();
        CanPickUp();
    }

    private void CheckItem()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask)) //������ ���̾�� �����ϵ��� ���̾� ����ũ ����
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
    }

    private void CanPickUp()
    {
        if(Input.GetKeyDown(KeyCode.E) && pickupActivated)
        {
            ItemPickUp();
        }
    }   

    private void ItemInfoAppear()   //������ ���� ǥ��
    {
        pickupActivated = true; //���� �����ϵ��� true�� ��ȯ\
                                          
    }   

    private void ItemPickUp()
    {
        pickupActivated = false;
    }   

    private void InformationDisappear()
    {
        pickupActivated = false;
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
    }


}
