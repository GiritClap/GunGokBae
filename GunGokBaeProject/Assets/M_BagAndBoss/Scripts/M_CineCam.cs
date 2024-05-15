using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // �ó׸ӽ� ���� �ڵ�
using Photon.Pun; // PUN ���� �ڵ�

public class M_CineCam : MonoBehaviourPun
{
    public GameObject camPos;
    public GameObject camLookAt;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            // ���� �ִ� �ó׸ӽ� ���� ī�޶� ã��
            CinemachineVirtualCamera followCam =
                FindObjectOfType<CinemachineVirtualCamera>();
            // ���� ī�޶��� ���� ����� �ڽ��� Ʈ���������� ����
            followCam.gameObject.transform.position = camPos.transform.position;
            followCam.Follow = camPos.transform;
            followCam.LookAt = camLookAt.transform;
        }
    }

   
}
