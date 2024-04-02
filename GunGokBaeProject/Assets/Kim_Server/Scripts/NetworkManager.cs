using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Text StatusText;
    public InputField roomInput, NickNameInput;


    void Awake() => Screen.SetResolution(1920, 1080, false);

    void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();



    public void Connect() => PhotonNetwork.ConnectUsingSettings(); //�Լ� ȣ�� (OnConnectedToMaster)

    public override void OnConnectedToMaster() //�ݹ� �Լ�  (ConnectUsingSettings)
    {
        print("�������ӿϷ�");
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text; //UI�� �ۼ��� �г����� �޾� ��

   
    }



    public void Disconnect() => PhotonNetwork.Disconnect(); //�Լ� ȣ�� (OnDisconnected)

    public override void OnDisconnected(DisconnectCause cause) => print("�������"); //�ݹ� �Լ�  (Disconnect)



    public void JoinLobby() => PhotonNetwork.JoinLobby(); //�κ� ����(�� )����)

    public override void OnJoinedLobby()=> print("�κ����ӿϷ�"); //�� ����     
  


    // �� �� �Լ� ���� Join �� OnConnectedToMaster �� �Ǿ� �־�� ��� ����
    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 5 });

    public void JoinRoom() => PhotonNetwork.JoinRoom(roomInput.text);

    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 5 }, null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    public override void OnCreatedRoom() => print("�游���Ϸ�");

    public override void OnJoinedRoom()
    {
        print("�������Ϸ�");

        SceneManager.LoadScene("Fire Planet");

        PhotonNetwork.Instantiate("MyPlayer", Vector3.zero, Quaternion.identity);
    }

     

    public override void OnCreateRoomFailed(short returnCode, string message) => print("�游������");

    public override void OnJoinRoomFailed(short returnCode, string message) => print("����������");

    public override void OnJoinRandomFailed(short returnCode, string message) => print("�淣����������");



    [ContextMenu("����")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("���� �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
            print("���� �� �ο��� : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("���� �� �ִ��ο��� : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "�濡 �ִ� �÷��̾� ��� : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("������ �ο� �� : " + PhotonNetwork.CountOfPlayers);
            print("�� ���� : " + PhotonNetwork.CountOfRooms);
            print("��� �濡 �ִ� �ο� �� : " + PhotonNetwork.CountOfPlayersInRooms);
            print("�κ� �ִ���? : " + PhotonNetwork.InLobby);
            print("����ƴ���? : " + PhotonNetwork.IsConnected);
        }
    }
}
