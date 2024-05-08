using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using MySql.Data.MySqlClient;
using System;


public class SaveData //저장할 데이터 쭉 적기
{


    //player 정보
    public bool ishost = false; //호스트 여부, 호스트 1 클라 0
    public string id; //아이디
    public string pw; //비밀번호
    public string nickname; //닉네임

    //----------------------------------------------
    
    //게임 캐릭터 정보
    public int playerHp;    //플레이어 체력
    public Vector3 playerPos; //플레이어 위치
    public Vector3 playerRot; //플레이어 위치
    
    public int level; //레벨
    public int totalExp; //전체 경험치?
    public int currentExp; //현재 경험치
    public int maxExp; //최대 경험치
    public int gold; //골드?
    //----------------------------------------------
    public string[] inventory = new string[6]; //인벤토리 곡괭이, 배냥, 총, 특수총 등등
    public int currentWep;      //들고 있는 현재 총기

    //----------------------------------------------
    //총기 정보 추가
    public String gunName0; //총기이름
    public bool special_gun0; //특수총기 여부 일반총 0 특수총 1
    public int bulletCntInMag0; //총알 갯수
    public int bulletMaxInMag0; //최대 총알 갯수
    public int bulletInMag0; //탄창에 남은 총알
    //강화 정보 추가
    //----------------------------------------------

    //광물 정보 추가
    public int meneral0; //광물
    public int meneral1; //광물
    public int meneral2; //광물
    public int meneral3; //광물
    
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //host일경우 업데이트 정보
    //게임 정보

    //특수 무기 어디까지 먹었나???
    //현재 발견된 측수총 추가
    public string[] special_gun = new string[6];    //특수무기
    public int specialNum;          //특수무기 갯수
    public int currentSpecialGun;   //현재 특수무기
    //----------------------------------------------
    //게임 정보 gameManager

    public int sceneLevel;  //씬 레벨
    //public int currentStage;    //현재 스테이지
    //현재 진행 상황 번호? 추가
    //우주선 정보 추가
}

public class AcceptAllCertificates : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        // 모든 인증서를 수락합니다.
        return true;
    }
}
public class Han_SaveNLoad_DB : MonoBehaviour
{
    private const string S = "http://localhost/saveData.php";
    private string saveDataUrl = S; //php URL

    private const string L = "http://localhost/loadData.php";
    private string LoadDataUrl = L; //php URL

    public Text dataTxt;
    private SaveData saveData = new();

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
    void Start()
    {

    }
    public void SaveData()
    {
        //객체에 대이터 저장
        saveData.inventory[0] = "gun";
        saveData.inventory[1] = "pick";
        saveData.inventory[2] = "healgun";


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
    
     public IEnumerator LoadData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(LoadDataUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // 데이터 처리
                string data = www.downloadHandler.text;
                SaveData saveData = JsonUtility.FromJson<SaveData>(data);

                // 데이터 사용
                // 예: 플레이어 위치 설정, 점수 표시 등
            }
        }
    }

}

//json으로 클라이언트에 저장 //json으로 클라이언트에 저장 //json으로 클라이언트에 저장 //json으로 클라이언트에 저장 //json으로 클라이언트에 저장
/*    //json 파일로 저장시 디렉토리, 파일이름저장
    //private string SAVE_DATA_DIRECTORY; //디렉토리 경로
    //private string SAVE_FILENAME = "/DataSaveTest.txt"; //파일 이름 //나중에는 ID_data 형식으로 저장하여 구별

    //private PlayerController thePlayer; //player position //플레이어 위치 저장하는 튜토리얼
    

    void Start()
    {
        //json 파일로 저장하는 법
*//*        SAVE_DATA_DIRECTORY = Application.dataPath + "/Han/Saves/"; //path 입력

        if(!Directory.Exists(SAVE_DATA_DIRECTORY))  //디렉토리 없으면 생성
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }*//*
    }

    public void SaveData()
    {
        //thePlayer = FindObjectOfType<PlayerController>(); //플레이어 위치 저장하는 튜토리얼
        //saveData.playerPos = thePlayer.transform.position;
        //saveData.playerRot = thePlayer.transform.eulerAngles;

        //객체에 대이터 저장
        saveData.inventory[0] = "gun";
        saveData.inventory[1] = "pick";
        saveData.inventory[2] = "healgun";
        saveData.score = 30;

        //json으로 변경
        string json = JsonUtility.ToJson(saveData);

        //파일 저장
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json); //파일 저장

        //Debug.Log("저장 완료");
        //Debug.Log(json);
    }

    public void LoadData()
    {
        if(File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME)) {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            //GameObject player = GameObject.Find("Player") //이름으로 찾음 -> 진짜 오래걸림
            //GameObject player = GameObject.FindWithTag("Player") //태그를 이용한 검색 -> 오래걸림


            //thePlayer = FindObjectOfType<PlayerController>(); //PlayerController컴포넌트가 붙은 처음
            //thePlayer.transform.position = saveData.playerPos; //받아온 데이터를 캐릭터 위치에 저장
            //thePlayer.transform.eulerAngles = saveData.PlayerRot; // 회전
            Debug.Log("로드 완료");
            dataTxt.text = saveData.inventory[0]+"\n"+ saveData.inventory[1] + "\n"+ saveData.inventory[2] + "\n" + saveData.score +"\n";
        }
        else
        {
            Debug.Log("세이브 파일이 없습니다.");
        }*/

