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
    public GameObject gokUpgradePanel;
    public GameObject[] gokUpgradeNum;
    public GameObject goksPanel;
    public M_GunManager manageGun;
    public M_GokManager manageGok;
    public Image crosshair;

    int clickGokNum = 0;
    int clickGunNum = 0;    

    private void Start()
    {
        manageGun = GameObject.Find("OriginalGun").GetComponent<M_GunManager>();
        //manageGok = GameObject.Find("Pick").GetComponent<M_GokManager>();
    }

    private void Update()
    {
        if (manageGun == null)
        {
            manageGun = GameObject.Find("OriginalGun").GetComponent<M_GunManager>();
        }
        if(manageGok == null)
        {
            manageGok = GameObject.Find("Pick").GetComponent<M_GokManager>();
        }
    }

    //여기서부터 기본총 업그레이드
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
        clickGunNum = 0;
    }

    public void GunUpgrade()
    {
        if (clickGunNum > 4)
        {
            GunReset();
            gunUpgradePanel.SetActive(false);
            gunsPanel.SetActive(true);
            return;
        }
        gunUpgradeNum[clickGunNum].SetActive(true);
        clickGunNum++;
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

    // 여기서부터 곡괭이 업그레이드
    public void GokBtn()
    {
        upgradePanel.SetActive(false);
        gokUpgradePanel.SetActive(true);
    }

    public void GokCancel()
    {
        upgradePanel.SetActive(true);
        gokUpgradePanel.SetActive(false);
    }

    public void GokReset()
    {
        for (int i = 0; i < gokUpgradeNum.Length; i++)
        {
            gokUpgradeNum[i].SetActive(false);
        }
        clickGokNum = 0;
    }

    public void GokUpgrade()
    {
        if (clickGokNum > 2)
        {
            GokReset();
            gokUpgradePanel.SetActive(false);
            goksPanel.SetActive(true);
            return;
        }
        gokUpgradeNum[clickGokNum].SetActive(true);
        clickGokNum++;
    }

    public void AttackGokBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGok.ChooseAttackGok();
        goksPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DefenseGokBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGok.ChooseDefenseGok();
        goksPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
