using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_NoGun : MonoBehaviour
{
    public Text bulletCntText;
    public Image crosshair;
    // Start is called before the first frame update
    void Start()
    {
        bulletCntText.text = "";
        //crosshair.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "";

    }
}
