using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BtnSystem : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject gunUpgradePanel;
    public GameObject[] gunUpgradeNum;
    int clickNum = 0;
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
        for(int i = 0; i < gunUpgradeNum.Length; i++)
        {
            gunUpgradeNum[i].SetActive(false);
        }
        clickNum = 0;
    }

    public void GunUpgrade()
    {
        if(clickNum > 4)
        {
            return;
        }
        gunUpgradeNum[clickNum].SetActive(true);
        clickNum++;
    }

}
