using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletRocket : MonoBehaviour
{
    public GameObject bullet_rocket;

    public float BulletSpeed = 350;
    float destroyTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // ÃÑ¾Ë 3ÃÊ µÚ ÆÄ±«
        destroyTime += Time.deltaTime;
        if (destroyTime > 3.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        GameObject rocket = Instantiate(bullet_rocket);
        rocket.transform.position = this.transform.position;
    }
}
