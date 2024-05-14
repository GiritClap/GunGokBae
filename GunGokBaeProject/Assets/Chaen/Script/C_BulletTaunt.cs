using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletTaunt : MonoBehaviour
{
    public GameObject bullet_Taunt;
    public Transform Taunt_Position;

    float destroyTime = 0;

    public AudioClip tauntSpawnClip;
   
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
        GameObject taunt = Instantiate(bullet_Taunt, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
        M_SoundManager.instance.SFXPlay("tauntSpawn", tauntSpawnClip);

        Destroy(gameObject);
    }
}