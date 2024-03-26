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
        // �÷��̾ start���� �ʰ� �����Ǳ⶧���� ������Ʈ�� ���� ������ �˻� 
        if(cam == null)
        {
            cam = Camera.main.transform;
        }
        // �׻� ī�޶� ������ �ٶ󺸰� ��
        transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }
}
