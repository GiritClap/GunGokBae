using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_LoadingCtrl : MonoBehaviour
{
    public Slider bossHp;
    float maxBossHp = 100;
    public float currentBossHp = 0f;
    public Text currentBossHpTxt;

    private float randNum;
    private bool isStop;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStop == false) StartCoroutine(Loading());

        bossHp.value = currentBossHp / maxBossHp;
        currentBossHpTxt.text = currentBossHp.ToString("N0") + " / " + maxBossHp.ToString("N0");

        if(currentBossHp >= 100) { Destroy(this.gameObject); }
    }

    IEnumerator Loading()
    {
        isStop= true;
        randNum = Random.Range(10, 40);
        currentBossHp += randNum;
        if (currentBossHp >= 100) currentBossHp = 100f;
        yield return new WaitForSeconds(1.0f);
        isStop = false;
    }
}
