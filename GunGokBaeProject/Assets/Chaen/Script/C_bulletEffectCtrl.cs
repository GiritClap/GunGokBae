using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletEffectCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
    }
}
