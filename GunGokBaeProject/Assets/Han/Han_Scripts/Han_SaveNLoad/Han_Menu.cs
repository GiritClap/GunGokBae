using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.IO;

using static UnityEditor.Progress;

using UnityEngine.Networking;
using System.Text;
using MySql.Data.MySqlClient;
using System;


public class Han_Menu : MonoBehaviour
{
    private Han_SaveNLoad_DB saveNLoad;


    private const string S = "http://localhost/saveData.php";
    private string saveDataUrl = S; //php URL

    private const string L = "http://localhost/loadData.php";
    private string LoadDataUrl = L; //php URL

    public Text dataTxt;
    private SaveData saveData = new();




    void Start()
    {
        saveNLoad = GameObject.FindObjectOfType<Han_SaveNLoad_DB>();
    }

    
    // Start is called before the first frame update
    public void SaveDBBtn()
    {
        Debug.Log("ClickSave");
        saveNLoad.SaveData();
    }

    public void ExitBtn()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    public void LoadBtn()
    {
        StartCoroutine(LoadCoroutine());
        Debug.Log("데이터 로드");
    }

    IEnumerator LoadCoroutine()
    {
        //SceneManager.LoadScene(sceneName); //게임 씬으로 이동 후 데이터를 넣어줘야 하기 때문에
/*        
 *      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //동기화, 씬의 모든것이 로딩될때까지
        while (!operation.isDone)   //기다리기, 프래임단위로 검색
        {
            yield return null;
        }
*/
        saveNLoad.LoadData();
        //Destroy(gameObject);    //이거 왜 쓰는지 모르겠음
        yield return null; //나중에 지울것 (위에 씬이동 기다리는거 안쓰면)

    }
}

    
