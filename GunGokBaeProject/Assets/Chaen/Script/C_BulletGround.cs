using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class C_BulletGround : MonoBehaviour
{
    public GameObject bullet_ground;
    public Transform ground_Position;

    public float BulletSpeed = 500;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * BulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // 총알 3초 뒤 파괴
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCol();
        Debug.Log(collision.gameObject.name + "충돌");
    }

    void isCol() //물체랑 충돌했을 때
    {
        Destroy(gameObject);
        GameObject ground = Instantiate(bullet_ground);
        ground.transform.position = this.transform.position;
    }
}
