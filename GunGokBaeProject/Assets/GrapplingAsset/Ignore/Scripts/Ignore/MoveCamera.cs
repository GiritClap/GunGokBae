using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviourPun
{
    public Transform cameraPosition;

    private void Update()
    {
        // ���� �÷��̾ ���� ��ġ�� ȸ���� ���� ����
        if (!photonView.IsMine)
        {
            return;
        }
        transform.position = cameraPosition.position;
    }
}
