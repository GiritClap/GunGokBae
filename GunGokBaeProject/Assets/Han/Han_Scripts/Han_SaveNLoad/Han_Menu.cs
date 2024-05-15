using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


using System.IO;


using UnityEngine.Networking;
using System.Text;
using MySql.Data.MySqlClient;
using System;


public class Han_Menu : MonoBehaviour
{
        //--------------싱글톤--------------
    private static Han_Menu instance_Han_Menu = null;
    void Awake()
    {
        if (null == instance_Han_Menu)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance_Han_Menu = this;
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
    private Han_SaveNLoad_DB saveNLoad;


    private const string S = "http://localhost/saveData.php";
    private string saveDataUrl = S; //php URL

    private const string L = "http://localhost/loadData.php";
    private string LoadDataUrl = L; //php URL

    public Text dataTxt;
    private SaveData saveData = new();

    bool isBtnClickG = false;

    public GameObject SaveDataPanel;

    //public Image crosshair;
    public GameObject SaveNLoadCanvas;
    private List<GameObject> activeUIs; // 활성화된 UI를 추적하는 리스트
    private GameObject[] allObjects;
    void Start()
    {
        saveNLoad = GameObject.FindObjectOfType<Han_SaveNLoad_DB>();    //씬에 있는 SaveNLoad_DB를 찾아서 저장

        SaveNLoadCanvas = GameObject.Find("SaveNLoadCanvas");   //씬에 있는 SaveNLoadCanvas를 찾아서 저장
        SaveDataPanel = GameObject.Find("SaveDataPanel");       //씬에 있는 SaveDataPanel를 찾아서 저장
    

        SaveDataPanel.SetActive(false);                         //SaveDataPanel 비활성화



        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

        activeUIs = new List<GameObject>(); // 리스트 초기화
        allObjects = null;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            isBtnClickG = !isBtnClickG;

            if (isBtnClickG == true)
            {
                // 'Canvas'가 이름에 포함된 모든 활성화된 게임 오브젝트를 찾아 리스트에 저장합니다.
                allObjects = GameObject.FindObjectsOfType<GameObject>();
                if(allObjects != null){
                    foreach(GameObject go in allObjects)
                    {
                        if (go.name.Contains("Canvas") && go.activeSelf)
                        {
                            activeUIs.Add(go);
                            Debug.Log("SetActive False : "+go.name);
                            go.SetActive(false);
                        }
                    }
                }
                SaveNLoadCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SaveDataPanel.SetActive(true);

            }

            if(isBtnClickG == false)
            {
                if(allObjects != null){
                    // 리스트에 저장된 모든 게임 오브젝트를 활성화합니다.
                    foreach(GameObject UI in activeUIs)
                    {
                        UI.SetActive(true);
                    }
                    activeUIs.Clear(); // 리스트를 비웁니다.
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SaveDataPanel.SetActive(false);

            }
        }
    }
    

    
    // Start is called before the first frame update
    public void SaveDBBtn()
    {
        Debug.Log("ClickSave");
        saveNLoad.SaveDataToSQL();
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
        // AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //동기화, 씬의 모든것이 로딩될때까지
        // while (!operation.isDone)   //기다리기, 프래임단위로 검색    //sceneName받아 와야됨
        // {
        //     yield return null;
        // }

        saveNLoad.LoadData();
        //Destroy(gameObject);    //이거 왜 쓰는지 모르겠음
        yield return null; //나중에 지울것 (위에 씬이동 기다리는거 안쓰면)

    }
}

    
