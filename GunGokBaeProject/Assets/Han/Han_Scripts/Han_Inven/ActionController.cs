using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템을 줍는 스크립트 그냥 유튭 보고 따라함
//이거 안쓸듯

public class ActionController : MonoBehaviour   
{
    [SerializeField]
    private float range; //최대 습득 사거리?
    private bool pickupActivated = false; //습득 가능할 시 true
    private RaycastHit hitInfo; //충돌체 정보 저장

    [SerializeField]
    private LayerMask layerMask; //아이템 레이어에만 반응하도록 레이어 마스크 설정


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
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask)) //아이템 레이어에만 반응하도록 레이어 마스크 설정
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

    private void ItemInfoAppear()   //아이템 정보 표시
    {
        pickupActivated = true; //습득 가능하도록 true로 전환\
                                          
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
