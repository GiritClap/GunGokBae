using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using MySql.Data.MySqlClient;
using System;
using Photon.Pun;
using System.Linq;
using UnityEngine.SceneManagement;



public class SaveData
{
    //player 정보는 포톤에서 배열식으로 받아 옴
    //저장할 DATA들을 전역변수에 저장
    string RoomName ; //방 이름                 -- 0
    string masterID; //마스터 아이디            --  0 - 1
    public string sceneName;                                                       //현재 씬 이름          -- 1
    //int currentStage;                                                     //현재 스테이지 번호     -- 2
    //포톤서버 마스터의 아이디
    
    public string[] playerIdArray = new string[3];                                       //플레이어 아이디 배열   -- 3
    public string[] playerNickNameArray = new string[3];                                 //플레이어 이름(닉네임) 배열    -- 4
    public string[] playerPositionArray = new string[3];                                 //플레이어 위치 배열   -- 5
    public string[] playerRotationArray = new string[3];                                 //플레이어 회전 배열  -- 6
    public int[] playerCurHp = new int[3];                                               //플레이어 현재 체력 배열 -- 7
    public int[] playerMaxHp = new int[3];                                               //플레이어 최대 체력 배열 -- 8
 

    M_BagManager BagManager = M_BagManager.Instance;
    //광물 종류가 추가될때마다 stone변수 하나씩 추가
    public float stone;     //광물 -- 9
    public float stone2;    //광물 -- 10
    public float stone3;    //광물 -- 11
    public float stone4;    //광물 -- 12
    public float stone5;    //광물 -- 13

    //총 종류가 추가될때마다 gun변수 하나씩 추가
    public bool gun;    //총기 -- 14
    public bool gun2;   //총기 -- 15
    public bool gun3;   //총기 -- 16
    public bool gun4;   //총기 -- 17
    public bool gun5;   //총기 -- 18

    

    //총 data
    public int[] currentWeapon = new int[3]; // 0 = 권총, 1 = 머신건, 2 = 샷건, 3 = 스나이퍼    // -- 19
    public float[] cur_Bullet_Cnt = new float[3]; // 현재 총알수                                     // -- 20
    public float[] max_Bullet_Cnt = new float[3]; // 총 총알수                                       // -- 21
    public float[] damage = new float[3]; // 총 데미지                                               // -- 22

        public string GetMasterClientId()
    {
        if (PhotonNetwork.MasterClient != null)
        {
            ExitGames.Client.Photon.Hashtable masterClientProperties = PhotonNetwork.MasterClient.CustomProperties;

            if (masterClientProperties.ContainsKey("id"))
            {
                return (string)masterClientProperties["id"];
            }
        }

        return null;
    }
    public void GetPlayerInfo()   //플레이어 이름 받아오는 함수
        {   
            //    M_BagManager BagManager = M_BagManager.Instance;
            RoomName = PhotonNetwork.CurrentRoom.Name; //방 이름 받아옴         -- 0
            masterID = GetMasterClientId(); //마스터 아이디 받아옴                  -- 0 - 1
            //현재 씬의 이름을 받아온다.                                        -- 1
            Scene currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
            
            //GameManager에서 현재 스테이지 받아오기        // -- 2
            //currentStage = GameManager.Instance.CurrentStage;

            // 현재 방에 있는 모든 플레이어의 목록을 가져옵니다.
            List<Photon.Realtime.Player> players = PhotonNetwork.PlayerList.ToList(); //포톤에서 플레이어 리스트 받아옴

            GameObject[] playerObjectArray = new GameObject[3];                     //플레이어 오브젝트 배열

                                                                                //****포톤서버 켜지면 주석 풀기****
            for (int i = 0; i < players.Count ; i++)
            {
                // 플레이어 정보를 가져옵니다.
                if (PhotonNetwork.LocalPlayer != null) 
                {
                    ExitGames.Client.Photon.Hashtable accountInfo = PhotonNetwork.LocalPlayer.CustomProperties;

                    if (accountInfo.ContainsKey("id"))
                    {
                        playerIdArray[i] = (string)accountInfo["id"]; // 플레이어의 아이디      -- 3
                    }
                }
            
                Photon.Realtime.Player player = players[i];
                
                playerNickNameArray[i] = player.NickName; // 플레이어의 닉네임                 -- 4

                // 플레이어의 게임 오브젝트를 찾습니다.
                GameObject playerObject = PhotonView.Find(player.ActorNumber).gameObject;
                playerObjectArray[i] = playerObject;

                // 플레이어의 위치 정보를 가져옵니다.                                           -- 5
                Vector3 position = playerObject.transform.position;
                playerPositionArray[i] = $"{position.x},{position.y},{position.z}";;

                // 플레이어의 회전 정보를 가져옵니다.                                           -- 6
                Quaternion rotation = playerObject.transform.rotation;
                playerRotationArray[i] = $"{rotation.x},{rotation.y},{rotation.z},{rotation.w}";
        
                // //나중에 받을 떄
                // string[] tokens = positionString.Split(',');
                // Vector3 position = new Vector3(
                //     float.Parse(tokens[0]),
                //     float.Parse(tokens[1]),
                //     float.Parse(tokens[2]));
                // string[] tokens = quaternionString.Split(',');
                // Quaternion rotation = new Quaternion(
                //     float.Parse(tokens[0]),
                //     float.Parse(tokens[1]),
                //     float.Parse(tokens[2]),
                //     float.Parse(tokens[3]));
       

                // 플레이어의 체력 정보를 가져옵니다.
                C_PlayerStatus playerStatus = playerObject.transform.Find("Player").GetComponent<C_PlayerStatus>();
                playerCurHp[i] = playerStatus.curHp; // 현재 체력                           -- 7
                playerMaxHp[i] = playerStatus.maxHp; // 최대 체력                           -- 8

                //총기 정보 받아오기
                //GameObject playerObject = GameObject.Find("MyPlayer_Real");
                Transform originalGunTransform = playerObject.transform.Find("CameraHolder/PlayerCamera/OriginalGun");
  
                M_OriginalGun originalGun = originalGunTransform.GetComponent<M_OriginalGun>();
                M_Sniper sniper = originalGunTransform.GetComponent<M_Sniper>();
                M_Shotgun shotgun = originalGunTransform.GetComponent<M_Shotgun>();
                M_Machinegun machinegun = originalGunTransform.GetComponent<M_Machinegun>();

                // 먼저, 어떤 무기가 활성화되어 있는지를 나타내는 변수 설정이 필요합니다.
                // 예: String activeWeapon = "originalGun"; // 이는 예시이며, 실제로는 무기의 활성화 여부에 따라 결정되어야 합니다.

                
                String activeWeapon = ""; // 활성화된 무기를 저장할 변수
                if (originalGun.enabled) {
                    activeWeapon = "originalGun";
                } else if (sniper.enabled) {
                    activeWeapon = "sniper";
                } else if (shotgun.enabled) {
                    activeWeapon = "shotgun";
                } else if (machinegun.enabled) {
                    activeWeapon = "machinegun";
                }

                switch (activeWeapon) {
                    case "originalGun":
                        currentWeapon[i] = 0; // 0 = 권총                               // -- 19
                        cur_Bullet_Cnt[i] = originalGun.cur_Bullet_Cnt; // 현재 총알수  // -- 20
                        max_Bullet_Cnt[i] = originalGun.max_Bullet_Cnt; // 총 총알수    // -- 21
                        damage[i] = originalGun.damage; // 총 데미지                    // -- 22
                        break;
                    case "sniper":
                        currentWeapon[i] = 3; // 3 = 스나이퍼                           // -- 19
                        cur_Bullet_Cnt[i] = sniper.cur_Bullet_Cnt; // 현재 총알수       // -- 20
                        max_Bullet_Cnt[i] = sniper.max_Bullet_Cnt; // 총 총알수         // -- 21
                        damage[i] = sniper.damage; // 총 데미지                         // -- 22
                        break;
                    case "shotgun":
                        currentWeapon[i] = 2; // 2 = 샷건                               // -- 19
                        cur_Bullet_Cnt[i] = shotgun.cur_Bullet_Cnt; // 현재 총알수      // -- 20
                        max_Bullet_Cnt[i] = shotgun.max_Bullet_Cnt; // 총 총알수        // -- 21
                        damage[i] = shotgun.damage; // 총 데미지                        // -- 22
                        break;
                    case "machinegun":
                        currentWeapon[i] = 1; // 1 = 머신건                             // -- 19
                        cur_Bullet_Cnt[i] = machinegun.cur_Bullet_Cnt; // 현재 총알수   // -- 20
                        max_Bullet_Cnt[i] = machinegun.max_Bullet_Cnt; // 총 총알수     // -- 21
                        damage[i] = machinegun.damage; // 총 데미지                     // -- 22
                        break;
                }
                //총기 정보 받아오기 끝



                
                Debug.Log("["+i+"]" + "씬 이름" + sceneName);
                Debug.Log("["+i+"]" + "플레이어 아이디" + playerIdArray[0]);
                Debug.Log("["+i+"]" + "플레이어 닉네임" + playerNickNameArray[0]);

                Debug.Log("["+i+"]" + "플레이어 위치" + playerPositionArray[0]);
                Debug.Log("["+i+"]" + "플레이어 회전" + playerRotationArray[0]);

                Debug.Log("["+i+"]" + "플레이어 현재 체력" + playerCurHp[0]);
                Debug.Log("["+i+"]" + "플레이어 최대 체력" + playerMaxHp[0]);

                Debug.Log("["+i+"]" + "총기" + currentWeapon);
                Debug.Log("["+i+"]" + "현재 총알수" + cur_Bullet_Cnt);
                Debug.Log("["+i+"]" + "총 총알수" + max_Bullet_Cnt);
                Debug.Log("["+i+"]" + "총 데미지" + damage);


        }


            stone = BagManager.stone;   //광물 -- 9
            stone2 = BagManager.stone2; //광물 -- 10
            stone3 = BagManager.stone3; //광물 -- 11
            stone4 = BagManager.stone4; //광물 -- 12
            stone5 = BagManager.stone5; //광물 -- 13

            //총 종류가 추가될때마다 gun변수 하나씩 추가
            gun = BagManager.GetGun();      //총기 -- 14
            gun2 = BagManager.GetGun2();    //총기 -- 15
            gun3 = BagManager.GetGun3();    //총기 -- 16
            gun4 = BagManager.GetGun4();    //총기 -- 17
            gun5 = BagManager.GetGun5();    //총기 -- 18





            Debug.Log("광물0" + stone);
            Debug.Log("광물2" + stone2);
            Debug.Log("광물3" + stone3);
            Debug.Log("광물4" + stone4);
            Debug.Log("광물5" + stone5);
            Debug.Log("총기0" + gun);
            Debug.Log("총기2" + gun2);
            Debug.Log("총기3" + gun3);
            Debug.Log("총기4" + gun4);
            Debug.Log("총기5" + gun5);

    }


    
}

//-----------------------------------유니티에서 DB로 데이터 저장하기-----------------------------------
public class Han_SaveNLoad_DB : MonoBehaviour
{
    private const string S = "http://localhost/saveData.php";
    private string saveDataUrl = S; //php URL

    private const string L = "http://localhost/loadData.php";
    private string LoadDataUrl = L; //php URL


    private SaveData saveData = new();

    //--------------싱글톤--------------
    private static Han_SaveNLoad_DB instance_Han_SaveNLoad_DB = null;
    void Awake()
    {
        if (null == instance_Han_SaveNLoad_DB)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance_Han_SaveNLoad_DB = this;
            //씬 전환이 되더라도 파괴되지 않게 한다.            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }
    //--------------싱글톤--------------

        
    public void SaveDataToSQL()
    {
        //객체에 대이터 저장
        saveData = new SaveData(); // Create an instance of SaveData class
        saveData.GetPlayerInfo(); // Call the GetPlayerInfo() method on the instance

        //json파일로 변경
        string json = JsonUtility.ToJson(saveData);

        StartCoroutine(PostRequest(saveDataUrl, json));
    }
        //json파일을 mysql로 보내기위하여 웹리쿼스트
        IEnumerator PostRequest(string url, string json)
    {
        var request = new UnityWebRequest(url, "POST"); //Post요청

        // SSL 인증서 검증을 비활성화합니다.
        request.certificateHandler = new AcceptAllCertificates();

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);        // JSON 문자열을 바이트 배열로 변환합니다.
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);        // 요청 본문에 JSON 데이터를 설정합니다.
        request.downloadHandler = new DownloadHandlerBuffer();        // 요청의 응답을 처리할 핸들러를 설정합니다.
        request.SetRequestHeader("Content-Type", "application/json");        // 요청 헤더에 Content-Type을 설정합니다.

        // 요청을 보냅니다. 이는 비동기적으로 처리되므로 yield return을 사용하여 완료를 기다립니다.
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)     // 요청이 성공적으로 완료되었는지 확인합니다.
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    [Obsolete]
    public IEnumerator LoadData()
    {
        // 요청을 생성합니다.
        WWWForm form = new WWWForm();
        form.AddField("masterID", GetMasterClientId());
        form.AddField("roomName", PhotonNetwork.CurrentRoom.Name);

        UnityWebRequest www = UnityWebRequest.Post(LoadDataUrl, form);

        // 요청을 보냅니다.
        yield return www.SendWebRequest();

        // 에러가 있는지 확인합니다.
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // 결과를 받아옵니다.
            string result = www.downloadHandler.text;

            // 결과를 JSON 형식으로 변환합니다.
            SaveData saveData = JsonUtility.FromJson<SaveData>(result);

            // 정보를 초기화합니다.
                
            M_BagManager BagManager = M_BagManager.Instance;
            Scene currentScene = SceneManager.GetActiveScene();
            
            currentScene.name = saveData.sceneName;
            
            //GameManager에서 현재 스테이지 받아오기        // -- 2
            //GameManager.Instance.CurrentStage = saveData.currentStage;

            // 현재 방에 있는 모든 플레이어의 목록을 가져옵니다.
            List<Photon.Realtime.Player> players = PhotonNetwork.PlayerList.ToList(); //포톤에서 플레이어 리스트 받아옴


            string[] playerIdArray = new string[3];                                 
            for (int i = 0; i < players.Count ; i++)
            {
                int curplayerIndex;
                // 플레이어 정보를 가져옵니다.
                if (PhotonNetwork.LocalPlayer != null) 
                {
                    ExitGames.Client.Photon.Hashtable accountInfo = PhotonNetwork.LocalPlayer.CustomProperties;

                    if (accountInfo.ContainsKey("id"))
                    {
                        playerIdArray[i] = (string)accountInfo["id"]; // 플레이어의 아이디      -- 3
                    }
                }

                for(int j = 0; j < 3; j++){             //플레이어 아이디 배열과 저장된 아이디 배열 비교
                    if(playerIdArray[j] == saveData.playerIdArray[i]){
                        curplayerIndex = j; //플레이어 아이디가 맞으면 배열 위치 저장

                    
                        Photon.Realtime.Player player = players[i];
                        

                        // 플레이어의 게임 오브젝트를 찾습니다.
                        //위치 저장
                        GameObject playerObject = PhotonView.Find(player.ActorNumber).gameObject;
                        string[] tokens1 = saveData.playerPositionArray[curplayerIndex].Split(',');
                        Vector3 position = new Vector3(
                            float.Parse(tokens1[0]),
                            float.Parse(tokens1[1]),
                            float.Parse(tokens1[2]));

                        playerObject.transform.position = position;

                        //플레이어의 회전 정보를 저장  
                        string[] tokens2 = saveData.playerRotationArray[curplayerIndex].Split(',');
                        Quaternion rotation = new Quaternion(
                            float.Parse(tokens2[0]),
                            float.Parse(tokens2[1]),
                            float.Parse(tokens2[2]),
                            float.Parse(tokens2[3]));

                        playerObject.transform.rotation = rotation;
                



                        // 플레이어의 체력 정보를 가져옵니다.
                        C_PlayerStatus playerStatus = playerObject.transform.Find("Player").GetComponent<C_PlayerStatus>();
                        playerStatus.curHp = saveData.playerCurHp[curplayerIndex]; // 현재 체력                           -- 7
                        playerStatus.maxHp = saveData.playerMaxHp[curplayerIndex]; // 최대 체력                           -- 8

                        //총기 정보 받아오기
                        //GameObject playerObject = GameObject.Find("MyPlayer_Real");
                        Transform originalGunTransform = playerObject.transform.Find("CameraHolder/PlayerCamera/OriginalGun");
        
                        M_OriginalGun originalGun = originalGunTransform.GetComponent<M_OriginalGun>();
                        M_Sniper sniper = originalGunTransform.GetComponent<M_Sniper>();
                        M_Shotgun shotgun = originalGunTransform.GetComponent<M_Shotgun>();
                        M_Machinegun machinegun = originalGunTransform.GetComponent<M_Machinegun>();


                        originalGun.enabled = false;
                        sniper.enabled = false;
                        shotgun.enabled = false;
                        machinegun.enabled = false;

                        switch (saveData.currentWeapon[curplayerIndex]) {
                            case 0:
                                originalGun.enabled = true;
                                originalGun.cur_Bullet_Cnt = saveData.cur_Bullet_Cnt[curplayerIndex]; // 현재 총알수  // -- 20
                                originalGun.max_Bullet_Cnt = saveData.max_Bullet_Cnt[curplayerIndex]; // 총 총알수    // -- 21
                                originalGun.damage = saveData.damage[curplayerIndex]; // 총 데미지                    // -- 22
                                break;
                            case 3:
                                sniper.enabled = true;
                                sniper.cur_Bullet_Cnt = saveData.cur_Bullet_Cnt[curplayerIndex]; // 현재 총알수  // -- 20
                                sniper.max_Bullet_Cnt = saveData.max_Bullet_Cnt[curplayerIndex]; // 총 총알수    // -- 21
                                sniper.damage = saveData.damage[curplayerIndex]; // 총 데미지                    // -- 22

                                break;
                            case 2:
                                shotgun.enabled = true;
                                shotgun.cur_Bullet_Cnt = saveData.cur_Bullet_Cnt[curplayerIndex]; // 현재 총알수  // -- 20
                                shotgun.max_Bullet_Cnt = saveData.max_Bullet_Cnt[curplayerIndex]; // 총 총알수    // -- 21
                                shotgun.damage = saveData.damage[curplayerIndex]; // 총 데미지                    // -- 22
                                break;
                            case 1:
                                machinegun.enabled = true;
                                machinegun.cur_Bullet_Cnt = saveData.cur_Bullet_Cnt[curplayerIndex]; // 현재 총알수  // -- 20
                                machinegun.max_Bullet_Cnt = saveData.max_Bullet_Cnt[curplayerIndex]; // 총 총알수    // -- 21
                                machinegun.damage = saveData.damage[curplayerIndex]; // 총 데미지                    // -- 22
                                break;
                        
                            //총기 정보 받아오기 끝

                        }
                    

                            break;
                        
                    }
                }

            }
        }
    }

    public string GetMasterClientId()
    {
        if (PhotonNetwork.MasterClient != null)
        {
            ExitGames.Client.Photon.Hashtable masterClientProperties = PhotonNetwork.MasterClient.CustomProperties;

            if (masterClientProperties.ContainsKey("id"))
            {
                return (string)masterClientProperties["id"];
            }
        }

        return null;
    }

}
public class AcceptAllCertificates : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        // 모든 인증서를 수락합니다.
        return true;
    }
}



// public class TestSaveData //저장할 데이터 쭉 적기
// {


//     //player 정보
//     //public bool ishost = false; //호스트 여부, 호스트 1 클라 0
//     public string id; //아이디
//     public string pw; //비밀번호
//     public string nickname; //닉네임

//     //----------------------------------------------
    
//     //게임 캐릭터 정보
//     public int playerHp;    //플레이어 체력
//     public Vector3 playerPos; //플레이어 위치
//     public Vector3 playerRot; //플레이어 위치
    
//     public int level; //레벨
//     public int totalExp; //전체 경험치?
//     public int currentExp; //현재 경험치
//     public int maxExp; //최대 경험치
//     public int gold; //골드?
//     //----------------------------------------------
//     public string[] inventory = new string[6]; //인벤토리 곡괭이, 배냥, 총, 특수총 등등
//     public int currentWep;      //들고 있는 현재 총기

//     //----------------------------------------------
//     //총기 정보 추가
//     public String gunName0; //총기이름
//     public bool special_gun0; //특수총기 여부 일반총 0 특수총 1
//     public int bulletCntInMag0; //총알 갯수
//     public int bulletMaxInMag0; //최대 총알 갯수
//     public int bulletInMag0; //탄창에 남은 총알
//     //강화 정보 추가
//     //----------------------------------------------

//     //광물 정보 추가
//     public int meneral0; //광물
//     public int meneral1; //광물
//     public int meneral2; //광물
//     public int meneral3; //광물
    
//     //----------------------------------------------------------------------
//     //----------------------------------------------------------------------
//     //host일경우 업데이트 정보
//     //게임 정보

//     //특수 무기 어디까지 먹었나???
//     //현재 발견된 측수총 추가
//     public string[] special_gun = new string[6];    //특수무기
//     public int specialNum;          //특수무기 갯수
//     public int currentSpecialGun;   //현재 특수무기
//     //----------------------------------------------
//     //게임 정보 gameManager

//     public int sceneLevel;  //씬 레벨
//     //public int currentStage;    //현재 스테이지
//     //현재 진행 상황 번호? 추가
//     //우주선 정보 추가
    
// }