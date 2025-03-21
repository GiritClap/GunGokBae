using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_PlayerMiningUI : MonoBehaviour
{
 

    private GameObject uiManager;
    public Image crosshair;
    public GameObject upgradePanels;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIs");
        uiManager.SetActive(false);
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiManager.SetActive(true);
            crosshair.gameObject.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            uiManager.SetActive(false);
            crosshair.gameObject.SetActive(true);
        }
       

    }


   
}
