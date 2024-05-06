using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;

public class M_Gok : MonoBehaviour
{
    public Collider melee;
    public Text bulletCntText;
    public Image crosshair;

    public Animator anim;

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

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //ÁÂÅ¬¸¯
        {

            Debug.Log("melee true");

            melee.enabled = true;

            StartCoroutine("StartPicking");

        }
        if (Input.GetButtonUp("Fire1"))
        {
            melee.enabled = false;
        }
    }

    IEnumerator StartPicking()
    {
        anim.SetBool("Picking", true);
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("Picking", false);

    }

}

