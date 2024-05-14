using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BulletGround : MonoBehaviour
{
    public GameObject bullet_ground;

    public AudioClip groundSpawnClip;
   
    // Update is called once per frame
    void Update()
    {
        // ÃÑ¾Ë 3ÃÊ µÚ ÆÄ±«
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ground = Instantiate(bullet_ground, this.transform.position + new Vector3(0,-0.5f,0), Quaternion.identity);
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name + "Ãæµ¹");
        M_SoundManager.instance.SFXPlay("groundSpawn", groundSpawnClip);

    }
}
