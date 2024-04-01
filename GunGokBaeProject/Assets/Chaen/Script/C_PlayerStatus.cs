using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlayerStatus : MonoBehaviour
{
    public Image hpBar;
    public int curHp;
    public int maxHp;

    // Start is called before the first frame update

    void Awake()
    {
        maxHp = 100;
        curHp = 70;
    }
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateHp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag + " 충돌");
        if(collision.gameObject.tag == "Enemy")
        {
            this.attack();
        }
    }

    public void attack()
    {
        if(curHp > 0)
        {
            curHp -= 10;
            UpdateHp();
        }

        else if (curHp <= 0)
        {
            Debug.Log("플레이어 사망");
        }
    }

    public void heal()
    {
        if(curHp < maxHp)
        {
            curHp += 10;
            UpdateHp();
        }
    }

    void UpdateHp()
    {
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }
}
