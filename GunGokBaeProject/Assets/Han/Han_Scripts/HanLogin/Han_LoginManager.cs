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
        form.AddField("Input_user", IDInputField.text); //user 웹(PHP파일로)으로 전송
        form.AddField("Input_pass", PassInputField.text); //pass 웹(PHP파일로)으로 전송

        WWW webRequest = new(LoginUrl, form);  //저장된 URL로 이동
        yield return webRequest;
        Debug.Log(webRequest.text);
        loginText.text = webRequest.text;

        // 메시지 분석
        if (webRequest.text.Contains("Success to connect to database!"))
        {
            if (webRequest.text.Contains("Login successful!!"))
            {
                // 로그인 성공  //포톤에 id를 저장
                if (PhotonNetwork.LocalPlayer != null) 
                {
                    ExitGames.Client.Photon.Hashtable accountInfo = new ExitGames.Client.Photon.Hashtable(); 
                    accountInfo["id"] = IDInputField.text; 
                    PhotonNetwork.LocalPlayer.SetCustomProperties(accountInfo); 
                }



                // 다음 씬으로 이동
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








//메모장


//게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
//이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
//보안을 위해 private으로.
/*    private static LoginManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 헷갈림 방지를 위해 this를 붙여주기도 한다.
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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
