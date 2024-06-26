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
    public GameObject pick;

    public Animator anim;

    float timer;

    public AudioClip gokClip;
    // Start is called before the first frame update
    void Start()
    {
        bulletCntText.text = "Gok";

    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "Gok";
        timer += 1f * Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true && timer > 1.3f && pick.gameObject.activeSelf == true) //��Ŭ��
        {

            Debug.Log("melee true");

            melee.enabled = true;
            anim.SetBool("Picking", true);
            Invoke("StopPicking", 1.2f);
            M_SoundManager.instance.SFXPlay("gok", gokClip);

            timer = 0;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            melee.enabled = false;
            
        }
    }

    void StopPicking()
    {
        anim.SetBool("Picking", false);
    }
}

