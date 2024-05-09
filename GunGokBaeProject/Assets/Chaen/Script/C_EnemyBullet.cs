using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyBullet : MonoBehaviour
{
    public float BulletSpeed = 500;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<C_PlayerStatus>().Attack(5);
            Destroy(gameObject);
        }
    }
}
