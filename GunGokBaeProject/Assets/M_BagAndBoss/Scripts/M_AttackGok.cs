using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_AttackGok : MonoBehaviour
{
    public PlayerMovementGrappling playerMoveSpeed;
    public Collider melee;
    public Text bulletCntText;
    public Image crosshair;
   
    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = "AttackGok";
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        playerMoveSpeed = GameObject.Find("Player").GetComponent<PlayerMovementGrappling>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "AttackGok";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //좌클릭 -> 광물 채광
        {

            Debug.Log("Defense true");

            melee.enabled = true;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            melee.enabled = false;
        }

        if (Input.GetButton("Fire2") && crosshair.gameObject.activeSelf == true) //우클릭 -> 누르는동안 공격시스템 작동
        {

        }
        if (Input.GetButtonUp("Fire2"))
        {

        }
    }
}
