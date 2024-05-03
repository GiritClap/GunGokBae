using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_TextOnScreen : MonoBehaviour
{
    public Text[] stone;
    public Button[] btns;
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
        stone[3].text = "stone4 : " + M_BagManager.Instance.GetStone4().ToString();
        stone[4].text = "stone5 : " + M_BagManager.Instance.GetStone5().ToString();


        btns[0].gameObject.SetActive(M_BagManager.Instance.GetGun());
        btns[1].gameObject.SetActive(M_BagManager.Instance.GetGun2());
        btns[2].gameObject.SetActive(M_BagManager.Instance.GetGun3());
        btns[3].gameObject.SetActive(M_BagManager.Instance.GetGun4());
        btns[4].gameObject.SetActive(M_BagManager.Instance.GetGun5());

    }
}
