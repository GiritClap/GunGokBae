using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //public GameObject nowSpecialGun;

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
        player_ItemNum[2] = special_gun[5];
        nowItem = player_ItemNum[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player_ItemNum[0].SetActive(true);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(false);
            nowItem = player_ItemNum[0];
            

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
            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(true);
            nowItem = player_ItemNum[2];
        }
    }

    public void ChangeNoGun()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[0];
        player_ItemNum[2].SetActive(true);
    }

    public void ChangeGrappling()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[1];
        bulletCntText.text = "Grappling Gun";
        player_ItemNum[2].SetActive(true);
    }

    public void ChangeGround()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[2];
        bulletCntText.text = "Ground Gun";
        player_ItemNum[2].SetActive(true);
    }

    public void ChangeHeal()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[3];
        bulletCntText.text = "Heal Gun";
        player_ItemNum[2].SetActive(true);
    }

    public void ChangeRocket()
    {
        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_gun[4];
        bulletCntText.text = "Rocket Gun";
        player_ItemNum[2].SetActive(true);
    }
}
