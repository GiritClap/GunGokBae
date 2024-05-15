using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviourPun
{
    public Transform cameraPosition;

    private void Update()
    {
        // 로컬 플레이어만 직접 위치와 회전을 변경 가능
        if (!photonView.IsMine)
        {
            return;
        }
        transform.position = cameraPosition.position;
    }
}
