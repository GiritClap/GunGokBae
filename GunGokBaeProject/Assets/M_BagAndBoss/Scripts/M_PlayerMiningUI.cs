using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerMiningUI : MonoBehaviour
{
 

    private GameObject uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIs");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            uiManager.SetActive(true);
        }
        else
        {
            uiManager.SetActive(false);
        }

       
    }


   
}
