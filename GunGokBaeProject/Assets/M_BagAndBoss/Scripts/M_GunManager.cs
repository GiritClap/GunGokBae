using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GunManager : MonoBehaviour
{
    public M_OriginalGun originalGun;
    public M_Sniper sniper;
    public M_Shotgun shotgun;
    public M_Machinegun machinegun;


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
    }
}
