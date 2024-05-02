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
        // �Ѿ� 3�� �� �ı�
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCol();
        Debug.Log(collision.gameObject.name + "�浹");
    }

    void isCol() //��ü�� �浹���� ��
    {
        Destroy(gameObject);
        GameObject ground = Instantiate(bullet_ground);
        ground.transform.position = this.transform.position;
    }
}
