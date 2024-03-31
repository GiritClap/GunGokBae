using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BigBullet : MonoBehaviour
{
    public float bigBulletSpeed = 500;
    float destroyTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bigBulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // ÃÑ¾Ë 3ÃÊ µÚ ÆÄ±«
        destroyTime += Time.deltaTime;
        if(destroyTime > 3.0f)
        {
            Destroy(gameObject);
        }
    }
}
