using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_GrapplingGun : MonoBehaviour
{
    public GameObject gpGun;
    public Grappling gp;
    public Text bulletCntText;
    public Image crosshair;

    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        gp = GetComponentInChildren<Grappling>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gpGun.activeSelf && crosshair.gameObject.activeSelf == true)
        {
            bulletCntText.text = "Grappling";
            gp.enabled = true;
        }
        else
        {
            gp.enabled = false;

        }
    }
}
