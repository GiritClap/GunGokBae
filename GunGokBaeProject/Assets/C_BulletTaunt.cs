using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletTaunt : MonoBehaviour
{
    public GameObject bullet_Taunt;
    public Transform Taunt_Position;

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
        // �Ѿ� 3�� �� �ı�
        destroyTime += Time.deltaTime;
        if (destroyTime > 3.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCol();
        Debug.Log(collision.gameObject.name + "�浹");
    }

    void isCol() //��ü�� �浹���� ��
    {
        Destroy(gameObject);
        GameObject taunt = Instantiate(bullet_Taunt);
        taunt.transform.position = this.transform.position;
    }
}