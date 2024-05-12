using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_UpgradePanel : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject gunUpgradePanel;
    public GameObject gokUpgradePanel;
    public Image crosshair;

    // Start is called before the first frame update
    void Start()
    {
        /*upgradePanel = GameObject.Find("UpgradePanel");
        upgradePanel.SetActive(false);
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        gunUpgradePanel = GameObject.Find("GunUpgradePanel");
        gunUpgradePanel.SetActive(false);
        gokUpgradePanel = GameObject.Find("GokUpgradePanel");
        gokUpgradePanel.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UpgradeMachine")
        {
            Debug.Log("업그레이드 시스템 입장");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "UpgradeMachine")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                upgradePanel.SetActive(true);
                crosshair.gameObject.SetActive(false);
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                upgradePanel.SetActive(false);
                gunUpgradePanel.SetActive(false);
                crosshair.gameObject.SetActive(true);

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "UpgradeMachine")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            upgradePanel.SetActive(false);
            gunUpgradePanel.SetActive(false);
            gokUpgradePanel.SetActive(false);
            crosshair.gameObject.SetActive(true);

        }
    }
}
