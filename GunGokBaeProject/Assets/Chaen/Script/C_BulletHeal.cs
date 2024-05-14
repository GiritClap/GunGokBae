using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletHeal : MonoBehaviour
{
    float timer;
    float nowTime;

    

    // Start is called before the first frame update
    void Start()
    {
        timer = 4.0f;
        nowTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime > timer) { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(nowTime >= 3.9f)
            {
                other.GetComponent<C_PlayerStatus>().isHealBullet = false;
            }
        }
    }
}
