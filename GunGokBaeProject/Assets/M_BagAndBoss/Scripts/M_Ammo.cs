using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Ammo : MonoBehaviour
{
    GameObject playerCamera;

    M_GunManager m_GunManager;

    M_OriginalGun pistol;
    M_Machinegun machinegun;
    M_Shotgun shotgun;
    M_Sniper sniper;

    public AudioClip clip;
    private void Start()
    {
        playerCamera = GameObject.Find("PlayerCamera");
        m_GunManager = playerCamera.GetComponent<M_GunManager>();
        pistol = playerCamera.transform.Find("OriginalGun").GetComponent<M_OriginalGun>();
        machinegun = playerCamera.transform.Find("OriginalGun").GetComponent<M_Machinegun>();
        shotgun = playerCamera.transform.Find("OriginalGun").GetComponent<M_Shotgun>();
        sniper = playerCamera.transform.Find("OriginalGun").GetComponent<M_Sniper>();
    }
    private void Update()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            M_SoundManager.instance.SFXPlay("Ammo", clip);

            if (m_GunManager.CurrentWep() == 0)
            {
                pistol.PlusMaxBulletCnt(10);
            }
            else if (m_GunManager.CurrentWep() == 1)
            {
                machinegun.PlusMaxBulletCnt(10);
            }
            else if (m_GunManager.CurrentWep() == 2)
            {
                shotgun.PlusMaxBulletCnt(10);
            }
            else if (m_GunManager.CurrentWep() == 3)
            {
                sniper.PlusMaxBulletCnt(10);
            }

            Destroy(this.gameObject);
        }
    }
}
