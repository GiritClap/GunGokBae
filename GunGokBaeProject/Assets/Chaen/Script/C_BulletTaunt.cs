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
        // ÃÑ¾Ë 3ÃÊ µÚ ÆÄ±«
        destroyTime += Time.deltaTime;
        if (destroyTime > 3.0f)
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
        GameObject taunt = Instantiate(bullet_Taunt, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
        M_SoundManager.instance.SFXPlay("tauntSpawn", tauntSpawnClip);

        Destroy(gameObject);
    }
}