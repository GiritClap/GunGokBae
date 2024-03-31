using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Gok : MonoBehaviour
{
    public Collider melee;
    public Text bulletCntText;
    public Image crosshair;
    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = "Gok";
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "Gok";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //��Ŭ��
        {

            Debug.Log("melee true");

            melee.enabled = true;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            melee.enabled = false;
        }
    }
}
