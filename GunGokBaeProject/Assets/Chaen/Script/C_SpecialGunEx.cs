using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class C_SpecialGunEx : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterMouse()
    {
        img.gameObject.SetActive(true);
    }

    public void ExitMouse()
    {
        img.gameObject.SetActive(false);
    }
}
