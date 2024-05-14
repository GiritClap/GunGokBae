using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GunManager : MonoBehaviour
{
    public M_OriginalGun originalGun;
    public M_Sniper sniper;
    public M_Shotgun shotgun;
    public M_Machinegun machinegun;

    [Header("Mesh And Material")]
    public Mesh[] meshes; // 0 = 권총, 1 = 머신건, 2 = 샷건, 3 = 스나이퍼
    public MeshFilter meshFilter;
    public Material[] mat;// 0 = 권총, 1 = 머신건, 2 = 샷건, 3 = 스나이퍼
    public MeshRenderer meshRenderer;

    
    public int currentWeapon = 0; // 0 = 권총, 1 = 머신건, 2 = 샷건, 3 = 스나이퍼

    private void Start()
    {
        meshFilter = transform.GetChild(1).GetComponent<MeshFilter>();
        meshRenderer = transform.GetChild(1).GetComponent<MeshRenderer>();
    }

    public int CurrentWep()
    {
        return currentWeapon;
    }

    public string OriginalGunName()
    {
        return "Pistol";
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
        meshFilter.sharedMesh = meshes[1];
        meshRenderer.material = mat[1];
        transform.GetChild(1).transform.localPosition = new Vector3(0.568f, -0.469f, 0.655f);
        transform.GetChild(1).transform.localScale = new Vector3(2, 2, 2);

        currentWeapon = 1;
    }
    public void ChooseShotgun()
    {
        shotgun.enabled = true;
        originalGun.enabled = false;
        sniper.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[2];
        meshRenderer.material = mat[2];
        transform.GetChild(1).transform.localPosition = new Vector3(0.568f, -0.469f, 0.655f);
        transform.GetChild(1).transform.localScale = new Vector3(3, 2, 1.3f);

        currentWeapon = 2;

    }
   


    public void ChooseSniper()
    {
        sniper.enabled = true;
        originalGun.enabled = false;
        shotgun.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[3];
        meshRenderer.material = mat[3];
        transform.GetChild(1).transform.localPosition = new Vector3(0.568f, -0.469f, 0.655f);
        transform.GetChild(1).transform.localScale = new Vector3(2, 2, 1.6f);

        currentWeapon = 3;

    }

    public void ResetToOriginalGun()
    {
        originalGun.enabled = true;
        shotgun.enabled= false;
        sniper.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[0];
        meshRenderer.material = mat[0];
        transform.GetChild(1).transform.localPosition = new Vector3(0.568f, -0.469f, 0.655f);
        transform.GetChild(1).transform.localScale = new Vector3(2,2,2);

        originalGun.ResetToLevel1();
        machinegun.ResetToLevel1();
        shotgun.ResetToLevel1();
        sniper.ResetToLevel1();

        currentWeapon = 0;

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
