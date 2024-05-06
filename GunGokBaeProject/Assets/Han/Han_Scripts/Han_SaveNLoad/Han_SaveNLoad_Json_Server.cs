using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

/*public class SaveData //플레이어 위치 저장하는 튜토리얼
{
    public Vector3 playerPos;
    public Vector3 playerRot;
}*/


public class Han_SaveNLoad_Json_Server : MonoBehaviour
{
    private string dataUrl =  "http://localhost/SaveToJson.php"; //php URL

    public Text dataTxt;
    private SaveData saveData = new();

    void Start()
    {

    }
    public void SaveData()
    {
        //객체에 대이터 저장
        saveData.inventory[0] = "gun";
        saveData.inventory[1] = "pick";
        saveData.inventory[2] = "healgun";
        saveData.score = 30;

        //json파일로 변경
        string json = JsonUtility.ToJson(saveData);

        StartCoroutine(PostRequest(dataUrl, json));
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

