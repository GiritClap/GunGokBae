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



    public void Connect() => PhotonNetwork.ConnectUsingSettings(); //함수 호출 (OnConnectedToMaster)

    public override void OnConnectedToMaster() //콜백 함수  (ConnectUsingSettings)
    {
        print("서버접속완료");
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text; //UI에 작성한 닉네임을 받아 옴

   
    }



    public void Disconnect() => PhotonNetwork.Disconnect(); //함수 호출 (OnDisconnected)

    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김"); //콜백 함수  (Disconnect)



    public void JoinLobby() => PhotonNetwork.JoinLobby(); //로비 접속(예 )광장)

    public override void OnJoinedLobby()=> print("로비접속완료"); //방 들어가기     
  


    // 이 밑 함수 들은 Join 나 OnConnectedToMaster 가 되어 있어야 사용 가능
    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 5 });

    public void JoinRoom() => PhotonNetwork.JoinRoom(roomInput.text);

    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 5 }, null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    public override void OnCreatedRoom() => print("방만들기완료");

    public override void OnJoinedRoom()
    {
        print("방참가완료");

        SceneManager.LoadScene("Fire Planet");

        PhotonNetwork.Instantiate("MyPlayer", Vector3.zero, Quaternion.identity);
    }

     

    public override void OnCreateRoomFailed(short returnCode, string message) => print("방만들기실패");

    public override void OnJoinRoomFailed(short returnCode, string message) => print("방참가실패");

    public override void OnJoinRandomFailed(short returnCode, string message) => print("방랜덤참가실패");



    [ContextMenu("정보")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
        }
    }
}
