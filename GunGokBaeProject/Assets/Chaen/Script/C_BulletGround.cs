using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletGround : MonoBehaviour
{
    public GameObject bullet_ground;
   
    // Update is called once per frame
    void Update()
    {
        // �Ѿ� 3�� �� �ı�
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ground = Instantiate(bullet_ground, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name + "�浹");
    }
}
