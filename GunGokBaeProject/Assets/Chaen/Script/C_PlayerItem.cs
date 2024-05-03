using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;

public class C_PlayerItem : MonoBehaviour
{
    public GameObject gun;
    public GameObject pick;
    public GameObject[] special_gun = new GameObject[6];

    [Header("Special Guns")]
    [SerializeField] GameObject noGun;
    [SerializeField] GameObject grapplingGun;
    [SerializeField] GameObject groundGun;
    [SerializeField] GameObject healGun;
    [SerializeField] GameObject rocketGun;
    [SerializeField] GameObject tauntGun;

    public int specialNum;

    public GameObject[] player_ItemNum = new GameObject[3];
    public GameObject nowItem;

    public Text bulletCntText;


    [Header("Original Gun Rigs")]
    public M_GunManager gunManager;
    public Rig[] oriRigs; // 0 = ±ÇÃÑ, 1 = ¸Ó½Å°Ç, 2 = ¼¦°Ç, 3 = ½º³ªÀÌÆÛ

    [Header("Special Gun Rigs")]
    public Rig[] specRigs; // 0 = ¾øÀ½, 1 = °¥°í¸®ÃÑ, 2 = ±×¶ó¿îµå ÃÑ, 3 = Èú ÃÑ, 4 = ·ÎÄÏ ÃÑ, 5 = µµ¹ß ÃÑ

    //public GameObject nowSpecialGun;

    int currentSpecialGun = 0; // 0 = ¾øÀ½, 1 = °¥°í¸®ÃÑ, 2 = ±×¶ó¿îµå ÃÑ, 3 = Èú ÃÑ, 4 = ·ÎÄÏ ÃÑ, 5 = µµ¹ß ÃÑ

    // Start is called before the first frame update
    void Start()
    {
        special_gun[0] = noGun;
        special_gun[1] = grapplingGun;
        special_gun[2] = groundGun;
        special_gun[3] = healGun;
        special_gun[4] = rocketGun;
        special_gun[5] = tauntGun;
         

        player_ItemNum[0] = gun;
        player_ItemNum[1] = pick;
        player_ItemNum[2] = special_gun[0];
        nowItem = player_ItemNum[0];

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        if (gunManager.CurrentWep() == 0)
        {
            oriRigs[0].weight = 1;
        }
        if (gunManager.CurrentWep() == 1)
        {
            oriRigs[1].weight = 1;
        }
        if (gunManager.CurrentWep() == 2)
        {
            oriRigs[2].weight = 1;
        }
        if (gunManager.CurrentWep() == 3)
        {
            oriRigs[3].weight = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < specRigs.Length; i++)
            {
                specRigs[i].weight = 0;
            }
            for (int i = 0; i < oriRigs.Length; i++)
            {
                oriRigs[i].weight = 0;
            }

            player_ItemNum[0].SetActive(true);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(false);
            nowItem = player_ItemNum[0];
            
            if(gunManager.CurrentWep() == 0)
            {           
                oriRigs[0].weight = 1;
            }
            if (gunManager.CurrentWep() == 1)
            {               
                oriRigs[1].weight = 1;
            }
            if (gunManager.CurrentWep() == 2)
            {               
                oriRigs[2].weight = 1;
            }
            if (gunManager.CurrentWep() == 3)
            {        
                oriRigs[3].weight = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(true);
            player_ItemNum[2].SetActive(false);
            nowItem = player_ItemNum[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for(int i = 0; i < specRigs.Length; i++)
            {
                specRigs[i].weight = 0;
            }
            for (int i = 0; i < oriRigs.Length; i++)
            {
                oriRigs[i].weight = 0;
            }
            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(true);
            nowItem = player_ItemNum[2];

            if(currentSpecialGun == 0)
            {
                specRigs[0].weight = 1;
            }
            if (currentSpecialGun == 1)
            {
                specRigs[1].weight = 1;
            }
            if (currentSpecialGun == 2)
            {
                specRigs[2].weight = 1;
            }
            if (currentSpecialGun == 3)
            {
                specRigs[3].weight = 1;
            }
            if (currentSpecialGun == 4)
            {
                specRigs[4].weight = 1;
            }
            if (currentSpecialGun == 5)
            {
                specRigs[5].weight = 1;
            }
        }
    }

    public void ChangeNoGun()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[0];
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 0;
        specRigs[0].weight = 1;
    }

    public void ChangeGrappling()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[1];
        bulletCntText.text = "Grappling Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 1;
        specRigs[1].weight = 1;
    }

    public void ChangeGround()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[2];
        bulletCntText.text = "Ground Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 2;
        specRigs[2].weight = 1;
    }

    public void ChangeHeal()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[3];
        bulletCntText.text = "Heal Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 3;
        specRigs[3].weight = 1;
    }

    public void ChangeRocket()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[4];
        bulletCntText.text = "Rocket Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 4;
        specRigs[4].weight = 1;
    }

    public void ChangeTaunt()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[5];
        bulletCntText.text = "Taunt Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 5;
        specRigs[5].weight = 1;
    }
}
