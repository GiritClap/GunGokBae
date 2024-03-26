using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class C_BulletGround : MonoBehaviour
{
    public GameObject bullet_ground;
    public Transform ground_Position;

    public float BulletSpeed = 500;
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
        if(destroyTime > 3.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCol();
        Debug.Log(collision.gameObject.name + "Ãæµ¹");
    }

    void isCol() //¹°Ã¼¶û Ãæµ¹ÇßÀ» ¶§
    {
        Destroy(gameObject);
        GameObject ground = Instantiate(bullet_ground);
        ground.transform.position = this.transform.position;
    }
}
