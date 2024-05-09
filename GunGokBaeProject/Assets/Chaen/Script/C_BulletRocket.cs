using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletRocket : MonoBehaviour
{
    public GameObject bullet_rocket;
    public ParticleSystem boomEffect;

  

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        GameObject rocketEffect = Instantiate(boomEffect.gameObject, this.transform.position, Quaternion.identity);
        Destroy(rocketEffect, 3f);
        this.gameObject.SetActive(false);
        Destroy(this, 5f);
        
    }
}
