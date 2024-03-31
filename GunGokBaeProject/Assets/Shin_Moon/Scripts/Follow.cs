using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
   
    public Transform target; // 바라볼 타겟
    public Vector3 offset; // 카메라 위치

    void Update()
    {
        //정한 위치로 이동
        transform.position = target.position + offset;    
    }
}
