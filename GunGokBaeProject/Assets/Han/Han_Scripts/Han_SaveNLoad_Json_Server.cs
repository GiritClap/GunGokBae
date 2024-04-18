using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

/*public class SaveData //�÷��̾� ��ġ �����ϴ� Ʃ�丮��
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
        //��ü�� ������ ����
        saveData.inventory[0] = "gun";
        saveData.inventory[1] = "pick";
        saveData.inventory[2] = "healgun";
        saveData.score = 30;

        //json���Ϸ� ����
        string json = JsonUtility.ToJson(saveData);

        StartCoroutine(PostRequest(dataUrl, json));
    }
        //json������ mysql�� ���������Ͽ� ��������Ʈ
        IEnumerator PostRequest(string url, string json)
    {
        var request = new UnityWebRequest(url, "POST"); //Post��û

        // SSL ������ ������ ��Ȱ��ȭ�մϴ�.
        request.certificateHandler = new AcceptAllCertificates();

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);        // JSON ���ڿ��� ����Ʈ �迭�� ��ȯ�մϴ�.
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);        // ��û ������ JSON �����͸� �����մϴ�.
        request.downloadHandler = new DownloadHandlerBuffer();        // ��û�� ������ ó���� �ڵ鷯�� �����մϴ�.
        request.SetRequestHeader("Content-Type", "application/json");        // ��û ����� Content-Type�� �����մϴ�.

        // ��û�� �����ϴ�. �̴� �񵿱������� ó���ǹǷ� yield return�� ����Ͽ� �ϷḦ ��ٸ��ϴ�.
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)     // ��û�� ���������� �Ϸ�Ǿ����� Ȯ���մϴ�.
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}

//json���� Ŭ���̾�Ʈ�� ���� //json���� Ŭ���̾�Ʈ�� ���� //json���� Ŭ���̾�Ʈ�� ���� //json���� Ŭ���̾�Ʈ�� ���� //json���� Ŭ���̾�Ʈ�� ����
/*    //json ���Ϸ� ����� ���丮, �����̸�����
    //private string SAVE_DATA_DIRECTORY; //���丮 ���
    //private string SAVE_FILENAME = "/DataSaveTest.txt"; //���� �̸� //���߿��� ID_data �������� �����Ͽ� ����

    //private PlayerController thePlayer; //player position //�÷��̾� ��ġ �����ϴ� Ʃ�丮��
    

    void Start()
    {
        //json ���Ϸ� �����ϴ� ��
*//*        SAVE_DATA_DIRECTORY = Application.dataPath + "/Han/Saves/"; //path �Է�

        if(!Directory.Exists(SAVE_DATA_DIRECTORY))  //���丮 ������ ����
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }*//*
    }

    public void SaveData()
    {
        //thePlayer = FindObjectOfType<PlayerController>(); //�÷��̾� ��ġ �����ϴ� Ʃ�丮��
        //saveData.playerPos = thePlayer.transform.position;
        //saveData.playerRot = thePlayer.transform.eulerAngles;

        //��ü�� ������ ����
        saveData.inventory[0] = "gun";
        saveData.inventory[1] = "pick";
        saveData.inventory[2] = "healgun";
        saveData.score = 30;

        //json���� ����
        string json = JsonUtility.ToJson(saveData);

        //���� ����
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json); //���� ����

        //Debug.Log("���� �Ϸ�");
        //Debug.Log(json);
    }

    public void LoadData()
    {
        if(File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME)) {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            //GameObject player = GameObject.Find("Player") //�̸����� ã�� -> ��¥ �����ɸ�
            //GameObject player = GameObject.FindWithTag("Player") //�±׸� �̿��� �˻� -> �����ɸ�


            //thePlayer = FindObjectOfType<PlayerController>(); //PlayerController������Ʈ�� ���� ó��
            //thePlayer.transform.position = saveData.playerPos; //�޾ƿ� �����͸� ĳ���� ��ġ�� ����
            //thePlayer.transform.eulerAngles = saveData.PlayerRot; // ȸ��
            Debug.Log("�ε� �Ϸ�");
            dataTxt.text = saveData.inventory[0]+"\n"+ saveData.inventory[1] + "\n"+ saveData.inventory[2] + "\n" + saveData.score +"\n";
        }
        else
        {
            Debug.Log("���̺� ������ �����ϴ�.");
        }*/

