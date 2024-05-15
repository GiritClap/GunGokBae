using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // 시네머신 관련 코드
using Photon.Pun; // PUN 관련 코드

public class M_CineCam : MonoBehaviourPun
{
    public GameObject camPos;
    public GameObject camLookAt;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            // 씬에 있는 시네머신 가상 카메라를 찾고
            CinemachineVirtualCamera followCam =
                FindObjectOfType<CinemachineVirtualCamera>();
            // 가상 카메라의 추적 대상을 자신의 트랜스폼으로 변경
            followCam.gameObject.transform.position = camPos.transform.position;
            followCam.Follow = camPos.transform;
            followCam.LookAt = camLookAt.transform;
        }
    }

   
}
