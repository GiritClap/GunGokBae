using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Han_Menu : MonoBehaviour
{
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

    [SerializeField]
    private Han_SaveNLoad_DB theSaveNLoadDB;
    [SerializeField]
    private Han_SaveNLoad_Json_Server theSaveNLoadJson;
    
    // Start is called before the first frame update
    public void SaveDBBtn()
    {
        Debug.Log("ClickSave");
        theSaveNLoadDB.SaveData();
    }
    public void SaveServerBtn()
    {
        Debug.Log("ClickSave");
        theSaveNLoadJson.SaveData();
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
        //theSaveNLoad = FindObjectOfType<Han_SaveNLoad>(); �ٽ� �ҷ�����
        //theSaveNLoad.LoadData();
        Destroy(gameObject);
        yield return null; //���߿� �����

    }
}
