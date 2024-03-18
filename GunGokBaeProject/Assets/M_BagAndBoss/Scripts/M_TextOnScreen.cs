using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_TextOnScreen : MonoBehaviour
{
    public Text[] stone;
    public Image[] imgs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        stone[0].text = "stone1 : " + M_BagManager.Instance.GetStone().ToString();
        stone[1].text = "stone2 : " + M_BagManager.Instance.GetStone2().ToString();
        stone[2].text = "stone3 : " + M_BagManager.Instance.GetStone3().ToString();


        imgs[0].gameObject.SetActive(M_BagManager.Instance.GetGun());
        imgs[1].gameObject.SetActive(M_BagManager.Instance.GetGun2());
        imgs[2].gameObject.SetActive(M_BagManager.Instance.GetGun3());


    }
}
