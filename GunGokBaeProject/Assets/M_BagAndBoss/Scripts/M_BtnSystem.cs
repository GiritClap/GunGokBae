using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BtnSystem : MonoBehaviour
{
    [Header("In Gun")]
    public GameObject upgradePanel;
    public GameObject gunUpgradePanel;
    //public GameObject[] gunUpgradeNum;
    public GameObject gunsPanel;

    [Header("In Gok")]
    public GameObject gokUpgradePanel;
    public GameObject[] gokUpgradeNum;
    public GameObject goksPanel;

    [Header("UpgradeGunBtns In GUP")]
    public Button machinegunBtnInGUP;
    public Button shotgunBtnInGUP;
    public Button sniperBtnInGUP;

    [Header("UpgradeGun Builds")]
    public RectTransform machinegunBuild;
    public RectTransform shotgunBuild;
    public RectTransform sniperBuild;

    [Header("MachinegunBuild Upgrade Btns")]
    public Button[] machinegunUpgradeBtns; // 0 = lv5_1, 1 = lv7_1, 2 = lv10_1, 3 = lv5_2, 4 = lv7_2, 5 = lv10_2

    [Header("ShotgunBuild Upgrade Btns")]
    public Button[] shotgunUpgradeBtns; // 0 = lv5_1, 1 = lv7_1, 2 = lv10_1, 3 = lv5_2, 4 = lv7_2, 5 = lv10_2

    [Header("SniperBuild Upgrade Btns")]
    public Button[] sniperUpgradeBtns; // 0 = lv5_1, 1 = lv7_1, 2 = lv10_1, 3 = lv5_2, 4 = lv7_2, 5 = lv10_2

    public M_GunManager manageGun;
    public M_GokManager manageGok;
    public Image crosshair;

    [Header("Gun Info Text")]
    public Text gunLevel;
    public Text gunCurrent;
    public Text gunDamage;
    public Text gunBullet;

    bool isOriginalGun = true;
    bool chooseMachinegun = false;
    bool chooseShotgun = false;
    bool chooseSniper = false;

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
        gunLevel.text = "Level : " + clickGunNum.ToString();
        

        if(isOriginalGun)
        {
            gunCurrent.text = "CurrentGun : " + manageGun.OriginalGunName();
            gunDamage.text = "Damage : " + manageGun.CurrentOriginalGunDamage().ToString();
            gunBullet.text = "Bullet : " + manageGun.CurrentOriginalGunMaxBulletCnt().ToString();
        }
        if(chooseMachinegun)
        {
            gunCurrent.text = "CurrentGun : " + manageGun.MachinegunName();
            gunDamage.text = "Damage : " + manageGun.CurrentMachinegunDamage().ToString();
            gunBullet.text = "Bullet : " + manageGun.CurrentMachinegunMaxBulletCnt().ToString();
        }
        if(chooseShotgun)
        {
            gunCurrent.text = "CurrentGun : " + manageGun.ShotgunName();
            gunDamage.text = "Damage : " + manageGun.CurrentShotgunDamage().ToString();
            gunBullet.text = "Bullet : " + manageGun.CurrentShotgunMaxBulletCnt().ToString();
        }
        if(chooseSniper)
        {
            gunCurrent.text = "CurrentGun : " + manageGun.SniperName();
            gunDamage.text = "Damage : " + manageGun.CurrentSniperDamage().ToString();
            gunBullet.text = "Bullet : " + manageGun.CurrentSniperMaxBulletCnt().ToString();
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
        // 수정중
        machinegunBtnInGUP.gameObject.SetActive(false);
        shotgunBtnInGUP.gameObject.SetActive(false);
        sniperBtnInGUP.gameObject.SetActive(false);

        for(int i = 0; i < machinegunUpgradeBtns.Length; i++)
        {
            machinegunUpgradeBtns[i].interactable = false;
            shotgunUpgradeBtns[i].interactable = false;
            sniperUpgradeBtns[i].interactable = false;
        }

        manageGun.ResetToOriginalGun();

        isOriginalGun = true;
        chooseMachinegun = false;
        chooseShotgun = false;
        chooseSniper = false;

        clickGunNum = 0;
    }

    public void GunUpgrade()
    {
        // 수정중
        clickGunNum++;
        if(isOriginalGun)
        {
            manageGun.UpgradeOriginalGun();
        }
        if(chooseMachinegun)
        {
            manageGun.UpgradeMachinegun();
        }
        if(chooseShotgun)
        {
            manageGun.UpgradeShotgun();
        }
        if(chooseSniper)
        {
            manageGun.UpgradeSniper();
        }

        if(clickGunNum == 3)
        {
            gunsPanel.SetActive(true);
        }
        if(clickGunNum == 5)
        {
            machinegunUpgradeBtns[0].interactable = true;
            machinegunUpgradeBtns[3].interactable = true;

            shotgunUpgradeBtns[0].interactable = true;
            shotgunUpgradeBtns[3].interactable = true;

            sniperUpgradeBtns[0].interactable = true;
            sniperUpgradeBtns[3].interactable = true;
        }
        if(clickGunNum == 7)
        {
            machinegunUpgradeBtns[1].interactable = true;
            machinegunUpgradeBtns[4].interactable = true;

            shotgunUpgradeBtns[1].interactable = true;
            shotgunUpgradeBtns[4].interactable = true;

            sniperUpgradeBtns[1].interactable = true;
            sniperUpgradeBtns[4].interactable = true;
        }
        if(clickGunNum == 10)
        {
            machinegunUpgradeBtns[2].interactable = true;
            machinegunUpgradeBtns[5].interactable = true;

            shotgunUpgradeBtns[2].interactable = true;
            shotgunUpgradeBtns[5].interactable = true;

            sniperUpgradeBtns[2].interactable = true;
            sniperUpgradeBtns[5].interactable = true;
        }
    }

    public void ShotgunBtn()
    {
        chooseShotgun = true;
        isOriginalGun = false;
        shotgunBtnInGUP.gameObject.SetActive(true);
        manageGun.ChooseShotgun();
        gunsPanel.SetActive(false);
        
    }

    public void MachinegunBtn()
    {
        chooseMachinegun = true;
        isOriginalGun = false;
        machinegunBtnInGUP.gameObject.SetActive(true);
        manageGun.ChooseMachinegun();
        gunsPanel.SetActive(false);
        

    }

    public void SniperBtn()
    {
        chooseSniper = true;
        isOriginalGun = false;
        sniperBtnInGUP.gameObject.SetActive(true);
        manageGun.ChooseSniper();
        gunsPanel.SetActive(false);
        

    }

    // 여기부터 총 업그레이드 이후 버튼들
    public void MachinegunBuildBtn()
    {
        machinegunBuild.gameObject.SetActive(true);
        machinegunBuild.SetAsLastSibling();
    }
    public void MachinegunCancel()
    {
        machinegunBuild.gameObject.SetActive(false);
    }

    public void ShotgunBuildBtn()
    {
        shotgunBuild.gameObject.SetActive(true);
        shotgunBuild.SetAsLastSibling();
    }
    public void ShotgunCancel()
    {
        shotgunBuild.gameObject.SetActive(false);
    }

    public void SniperBuildBtn()
    {
        sniperBuild.gameObject.SetActive(true);
        sniperBuild.SetAsLastSibling();
    }
    public void SniperCancel()
    {
        sniperBuild.gameObject.SetActive(false);
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

    public void SpeedGokBtn()
    {
        crosshair.gameObject.SetActive(true);
        manageGok.ChooseSpeedGok();
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
