using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_HpControl : MonoBehaviour
{

    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 start보다 늦게 생성되기때문에 업데이트를 통해 꾸준히 검사 
        if(cam == null)
        {
            cam = Camera.main.transform;
        }
        // 항상 카메라 정면을 바라보게 함
        transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }
}
