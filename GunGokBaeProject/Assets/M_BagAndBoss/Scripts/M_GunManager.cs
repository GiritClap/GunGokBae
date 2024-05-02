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

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }


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
        meshFilter.sharedMesh = meshes[1];
        meshRenderer.material = mat[1];
        this.transform.localPosition = new Vector3(0.375f, -0.9f, 0.55f);
        this.transform.localScale = new Vector3(2, 2, 2);

    }

    public void ChooseSniper()
    {
        sniper.enabled = true;
        originalGun.enabled = false;
        shotgun.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[3];
        meshRenderer.material = mat[3];
        this.transform.localPosition = new Vector3(0.336f, -0.74f, 0.508f);
        this.transform.localScale = new Vector3(2, 2, 1.6f);
    }

    public void ChooseShotgun()
    {
        shotgun.enabled = true;
        originalGun.enabled = false;
        sniper.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[2];
        meshRenderer.material = mat[2];
        this.transform.localPosition = new Vector3(0.33f, -0.9f, 0.632f);
        this.transform.localScale = new Vector3(3, 2, 1.3f);

    }

    public void ResetToOriginalGun()
    {
        originalGun.enabled = true;
        shotgun.enabled= false;
        sniper.enabled = false;
        machinegun.enabled = false;
        meshFilter.sharedMesh = meshes[0];
        meshRenderer.material = mat[0];
        this.transform.localPosition = new Vector3(0.076f, -1.005f, 0.772f);
        this.transform.localScale = new Vector3(2,2,2);

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
