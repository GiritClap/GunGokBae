using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UnityWebRequestExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Ready1");
        StartCoroutine("LoadFromPhp");
    }

    void Update()
    {

    }

    IEnumerator LoadFromPhp()
    {
        string url = "http://localhost//index.php";
        WWW www = new WWW(url);
        Debug.Log("Ready2");
        yield return www;

        if (www.isDone)
        {
            if (www.error == null)
            {
                Debug.Log("Receive Data : " + www.text);
            }
            else
            {
                Debug.Log("error : " + www.error);
            }
        }
        Debug.Log("Ready3");
    }
}


