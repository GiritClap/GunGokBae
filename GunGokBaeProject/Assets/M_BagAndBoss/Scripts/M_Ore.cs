using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Ore : MonoBehaviour
{
    public int cnt = 0;
    bool isDamage = false;
    MeshRenderer mat;

    // 해당 광물에 어떤 광물과 총기를 드랍할 것 인지 등록
    public GameObject gun;
    public GameObject ore;

    Color oriCol;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>();
        oriCol = mat.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt > 2)
        {
            if(gun != null)
            {
                GameObject gg = Instantiate(gun, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
                gg.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 2, 1) * 100); // 광석이나 총기가 드랍될때 랜덤한 방향으로 튕겨나가기 // 추후 랜덤한 방향으로 바꿀것

            }
           
            GameObject oo = Instantiate(ore, this.transform.position + new Vector3(-1, 0, 0), this.transform.rotation);
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
        isDamage = true;
        cnt++;
        mat.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mat.material.color = oriCol;
        isDamage = false;
    }
}
