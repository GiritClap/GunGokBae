using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AmmoBox : MonoBehaviour
{
    public int cnt = 0;
    bool isDamage = false;
    public GameObject skin;
    SkinnedMeshRenderer mat;
    
    public GameObject ammo;
    public AudioClip clip;

  


    Color oriCol;
    // Start is called before the first frame update
    void Start()
    {
        mat = skin.GetComponent<SkinnedMeshRenderer>();
        oriCol = mat.material.color;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt <= 0)
        {
            
            GameObject oo = Instantiate(ammo, this.transform.position + new Vector3(-1, 0, 0), this.transform.rotation);
            oo.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 2, -1) * 100);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "melee" && isDamage == false)
        {
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        M_SoundManager.instance.SFXPlay("AmmoBoxHit", clip);
        isDamage = true;
        cnt--;
        mat.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mat.material.color = oriCol;
        isDamage = false;
    }
}
