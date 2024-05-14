using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlayerStatus : MonoBehaviour
{
    public Image hpBar;
    public Text hpText;
    public int curHp;
    public int maxHp;

    // Èú ÃÑ
    float healTimer;
    float healTime;
    public bool isHealBullet;   //

    public AudioClip healSound;
    // Start is called before the first frame update

    void Awake()
    {
        maxHp = 100;
        curHp = 70;
    }
    void Start()
    {
        UpdateHp();
        healTime = 5.0f;
        healTimer = 1.0f;
        isHealBullet = false;

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateHp();
        if (isHealBullet)
        {
            HealBottom();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //this.Attack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Heal") { 
                isHealBullet = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heal")
        {
            M_SoundManager.instance.SFXPlay("Healing", healSound);
        }

    }

    public void Attack(int damage)
    {
        if(curHp > 0)
        {
            curHp -= damage;
            UpdateHp();
        }

        else if (curHp <= 0)
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î »ç¸Á");
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
        hpText.text = curHp.ToString() + " / " + maxHp.ToString();
    }

    public void HealBottom()
    {
        healTime += Time.deltaTime;
        if(healTime > healTimer)
        {


            if (curHp < maxHp)
            {

                curHp += 5;
                UpdateHp();
            }
            healTime = 0.0f;
            isHealBullet = false;
        }
    }
}
