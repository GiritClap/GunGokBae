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
    public M_OriginalGun originalGun;
    public Image crosshair;

    int clickNum = 0;

    private void Start()
    {
        originalGun = GameObject.Find("OriginalGun").GetComponent<M_OriginalGun>();
    }
    private void Update()
    {
        if (originalGun == null)
        {
            originalGun = GameObject.Find("OriginalGun").GetComponent<M_OriginalGun>();
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
        originalGun.ChooseShotgun();
        gunsPanel.SetActive(false);
    }

    public void MachinegunBtn()
    {
        crosshair.gameObject.SetActive(true);
        originalGun.ChooseMachinegun();
        gunsPanel.SetActive(false);

    }

    public void SniperBtn()
    {
        crosshair.gameObject.SetActive(true);
        originalGun.ChooseSniper();
        gunsPanel.SetActive(false);

    }

}
