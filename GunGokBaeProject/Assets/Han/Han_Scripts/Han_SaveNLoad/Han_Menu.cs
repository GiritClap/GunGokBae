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
/*        
 *      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //����ȭ, ���� ������ �ε��ɶ�����
        while (!operation.isDone)   //��ٸ���, �����Ӵ����� �˻�
        {
            yield return null;
        }
*/
        saveNLoad.LoadData();
        //Destroy(gameObject);    //�̰� �� ������ �𸣰���
        yield return null; //���߿� ����� (���� ���̵� ��ٸ��°� �Ⱦ���)

    }
}

    
