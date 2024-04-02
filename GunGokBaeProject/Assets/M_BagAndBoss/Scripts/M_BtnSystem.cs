using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BtnSystem : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject gunUpgradePanel;
    public GameObject[] gunUpgradeNum;
    public GameObject gunsPanel;
    public M_GunManager manageGun;
    public Image crosshair;

    int clickNum = 0;

    private void Start()
    {
        manageGun = GameObject.Find("OriginalGun").GetComponent<M_GunManager>();
    }

    private void Update()
    {
        if (manageGun == null)
        {
            manageGun = GameObject.Find("OriginalGun").GetComponent<M_GunManager>();
        }
    }
    public void GunBtn()
    {
        upgradePanel.SetActive(false);
        gunUpgradePanel.SetActive(true);
    }

    public void GunCancel()
    {
        upgradePanel.SetActive(true);
        gunUpgradePanel.SetActive(false);
    }

    public void GunReset()
    {
        for (int i = 0; i < gunUpgradeNum.Length; i++)
        {
            gunUpgradeNum[i].SetActive(false);
        }
        clickNum = 0;
    }

    public void GunUpgrade()
    {
        if (clickNum > 4)
        {
            GunReset();
            gunUpgradePanel.SetActive(false);
            gunsPanel.SetActive(true);
            return;
        }
        gunUpgradeNum[clickNum].SetActive(true);
        clickNum++;
    }

    public void ShotgunBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGun.ChooseShotgun();
        gunsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MachinegunBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGun.ChooseMachinegun();
        gunsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void SniperBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGun.ChooseSniper();
        gunsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }



}
