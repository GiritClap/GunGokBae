using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GunManager : MonoBehaviour
{
    public M_OriginalGun originalGun;
    public M_Sniper sniper;
    public M_Shotgun shotgun;
    public M_Machinegun machinegun;


    public string OriginalGunName()
    {
        return "OriginalGun";
    }

    public string MachinegunName()
    {
        return "Machinegun";
    }

    public string ShotgunName()
    {
        return "Shotgun";
    }

    public string SniperName()
    {
        return "Sniper";
    }

    public void ChooseMachinegun()
    {
        machinegun.enabled = true;
        originalGun.enabled = false;
        sniper.enabled = false;
        shotgun.enabled = false;    
    }

    public void ChooseSniper()
    {
        sniper.enabled = true;
        originalGun.enabled = false;
        shotgun.enabled = false;
        machinegun.enabled = false;
    }

    public void ChooseShotgun()
    {
        shotgun.enabled = true;
        originalGun.enabled = false;
        sniper.enabled = false;
        machinegun.enabled = false;
    }

    public void ResetToOriginalGun()
    {
        originalGun.enabled = true;
        shotgun.enabled= false;
        sniper.enabled = false;
        machinegun.enabled = false;

        originalGun.ResetToLevel1();
        machinegun.ResetToLevel1();
        shotgun.ResetToLevel1();
        sniper.ResetToLevel1();
    }

    public void UpgradeOriginalGun() 
    { 
        originalGun.UpdateDamage(5);
        originalGun.UpgradeMaxBulletCnt(10);
    }

    public void UpgradeMachinegun()
    {
        machinegun.UpdateDamage(10);
        machinegun.UpgradeMaxBulletCnt(30);
    }

    public void UpgradeShotgun()
    {
        shotgun.UpdateDamage(5);
        shotgun.UpgradeMaxBulletCnt(7);
    }

    public void UpgradeSniper()
    {
        sniper.UpdateDamage(70);
        sniper.UpgradeMaxBulletCnt(4);
    }

    public float CurrentOriginalGunDamage()
    {
        return originalGun.CurrentDamage();
    }

    public float CurrentMachinegunDamage()
    {
        return machinegun.CurrentDamage();
    }

    public float CurrentShotgunDamage()
    {
        return shotgun.CurrentDamage();
    }

    public float CurrentSniperDamage()
    {
        return sniper.CurrentDamage();
    }

    public float CurrentOriginalGunMaxBulletCnt()
    {
        return originalGun.CurrentMaxBulletCnt();
    }

    public float CurrentMachinegunMaxBulletCnt()
    {
        return machinegun.CurrentMaxBulletCnt();
    }

    public float CurrentShotgunMaxBulletCnt()
    {
        return shotgun.CurrentMaxBulletCnt();
    }

    public float CurrentSniperMaxBulletCnt()
    {
        return sniper.CurrentMaxBulletCnt();
    }

    
}
