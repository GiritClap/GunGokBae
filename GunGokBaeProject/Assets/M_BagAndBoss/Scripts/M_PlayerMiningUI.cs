using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_PlayerMiningUI : MonoBehaviour
{
 

    private GameObject uiManager;
    public Image crosshair;

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
            crosshair.gameObject.SetActive(false);
        }
        else
        {
            uiManager.SetActive(false);
            crosshair.gameObject.SetActive(true) ;
        }


    }


   
}
