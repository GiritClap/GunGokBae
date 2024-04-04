using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerItem : MonoBehaviour
{
    //수정 예정
    public GameObject gun;
    public GameObject pick;
    public GameObject[] special_gun = new GameObject[4];

    [Header("Special Guns")]
    [SerializeField] GameObject noGun;
    [SerializeField] GameObject grapplingGun;
    [SerializeField] GameObject groundGun;
    [SerializeField] GameObject healGun;


    public int specialNum;

    public GameObject[] player_ItemNum = new GameObject[3];
    public GameObject nowItem;

    //public GameObject nowSpecialGun;

    // Start is called before the first frame update
    void Start()
    {
        special_gun[0] = noGun;
        special_gun[1] = grapplingGun;
        special_gun[2] = groundGun;
        special_gun[3] = healGun;
         

        player_ItemNum[0] = gun;
        player_ItemNum[1] = pick;
        player_ItemNum[2] = special_gun[3];
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
}
