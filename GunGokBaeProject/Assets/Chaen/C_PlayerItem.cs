using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerItem : MonoBehaviour
{
    public GameObject gun;
    public GameObject pick;

    public GameObject[] player_ItemNum = new GameObject[4];
    public GameObject nowItem;
    // Start is called before the first frame update
    void Start()
    {
        player_ItemNum[0] = gun;
        player_ItemNum[1] = pick;
        nowItem = player_ItemNum[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player_ItemNum[1].SetActive(false);
            player_ItemNum[0].SetActive(true);
            nowItem = player_ItemNum[0];
            

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(true);
            nowItem = player_ItemNum[1];
        }
    }
}
