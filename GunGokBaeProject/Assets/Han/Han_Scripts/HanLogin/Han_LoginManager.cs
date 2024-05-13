using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement ;
using Photon.Pun;
using Photon.Realtime;


public class Han_LoginManager : MonoBehaviour
{
    //[Header("LoginPanel")]
    public TMP_InputField IDInputField;
    public TMP_InputField PassInputField;
    //[Header("CreateAccountPanel")]
    public TMP_InputField New_IDInputField;
    public TMP_InputField New_PassInputField;

    public GameObject LoginPanel;
    public GameObject CAPanel;


    public Text loginText;
    public Text createText;

    private string LoginUrl;
    private string CreateAccountUrl;


    void Start()
    {
        LoginUrl = "http://localhost/Login.php";
        CreateAccountUrl = "http://localhost/CreateAccount.php";
    }


    public void LoginBtn()
    {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        Debug.Log(IDInputField.text);
        Debug.Log(PassInputField.text);

        WWWForm form = new();
        form.AddField("Input_user", IDInputField.text); //user ��(PHP���Ϸ�)���� ����
        form.AddField("Input_pass", PassInputField.text); //pass ��(PHP���Ϸ�)���� ����

        WWW webRequest = new(LoginUrl, form);  //����� URL�� �̵�
        yield return webRequest;
        Debug.Log(webRequest.text);
        loginText.text = webRequest.text;

        // �޽��� �м�
        if (webRequest.text.Contains("Success to connect to database!"))
        {
            if (webRequest.text.Contains("Login successful!!"))
            {
                // �α��� ����  //���濡 id�� ����
                if (PhotonNetwork.LocalPlayer != null) 
                {
                    ExitGames.Client.Photon.Hashtable accountInfo = new ExitGames.Client.Photon.Hashtable(); 
                    accountInfo["id"] = IDInputField.text; 
                    PhotonNetwork.LocalPlayer.SetCustomProperties(accountInfo); 
                }



                // ���� ������ �̵�
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }


    }
        public void CreateBtn()
    {
        StartCoroutine(CreateCo());
    }
    IEnumerator CreateCo()
    {
        Debug.Log(New_IDInputField.text);
        Debug.Log(New_PassInputField.text);

        WWWForm form = new();
        form.AddField("Input_user", New_IDInputField.text);
        form.AddField("Input_pass", New_PassInputField.text);

        WWW webRequest = new(CreateAccountUrl, form);
        yield return webRequest;
        Debug.Log(webRequest.text);

        LoginPanel.SetActive(true);
        CAPanel.SetActive(false);
        createText.text = webRequest.text;
    }

    public void OpenCreatPanelBtn()
    {
        LoginPanel.SetActive(false);
        CAPanel.SetActive(true);
    }

    public void back()
    {
        LoginPanel.SetActive(true);
        CAPanel.SetActive(false);
    }


}








//�޸���


//���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
//�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
//������ ���� private����.
/*    private static LoginManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static LoginManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }*/
