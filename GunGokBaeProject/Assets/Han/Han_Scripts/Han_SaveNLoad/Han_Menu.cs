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
        //--------------�̱���--------------
    private static Han_Menu instance_Han_Menu = null;
    void Awake()
    {
        if (null == instance_Han_Menu)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance_Han_Menu = this;
            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }
    //--------------�̱���--------------
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
    private List<GameObject> activeUIs; // Ȱ��ȭ�� UI�� �����ϴ� ����Ʈ
    private GameObject[] allObjects;
    void Start()
    {
        saveNLoad = GameObject.FindObjectOfType<Han_SaveNLoad_DB>();    //���� �ִ� SaveNLoad_DB�� ã�Ƽ� ����

        SaveNLoadCanvas = GameObject.Find("SaveNLoadCanvas");   //���� �ִ� SaveNLoadCanvas�� ã�Ƽ� ����
        SaveDataPanel = GameObject.Find("SaveDataPanel");       //���� �ִ� SaveDataPanel�� ã�Ƽ� ����
    

        SaveDataPanel.SetActive(false);                         //SaveDataPanel ��Ȱ��ȭ



        //crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

        activeUIs = new List<GameObject>(); // ����Ʈ �ʱ�ȭ
        allObjects = null;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            isBtnClickG = !isBtnClickG;

            if (isBtnClickG == true)
            {
                // 'Canvas'�� �̸��� ���Ե� ��� Ȱ��ȭ�� ���� ������Ʈ�� ã�� ����Ʈ�� �����մϴ�.
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
                    // ����Ʈ�� ����� ��� ���� ������Ʈ�� Ȱ��ȭ�մϴ�.
                    foreach(GameObject UI in activeUIs)
                    {
                        UI.SetActive(true);
                    }
                    activeUIs.Clear(); // ����Ʈ�� ���ϴ�.
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
        Debug.Log("��������");
        Application.Quit();
    }

    public void LoadBtn()
    {
        StartCoroutine(LoadCoroutine());
        Debug.Log("������ �ε�");
    }

    IEnumerator LoadCoroutine()
    {
        //SceneManager.LoadScene(sceneName); //���� ������ �̵� �� �����͸� �־���� �ϱ� ������
        // AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //����ȭ, ���� ������ �ε��ɶ�����
        // while (!operation.isDone)   //��ٸ���, �����Ӵ����� �˻�    //sceneName�޾� �;ߵ�
        // {
        //     yield return null;
        // }

        saveNLoad.LoadData();
        //Destroy(gameObject);    //�̰� �� ������ �𸣰���
        yield return null; //���߿� ����� (���� ���̵� ��ٸ��°� �Ⱦ���)

    }
}

    
