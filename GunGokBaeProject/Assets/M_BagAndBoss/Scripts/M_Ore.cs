using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Ore : MonoBehaviour
{
    public int cnt = 0;
    bool isDamage = false;
    MeshRenderer mat;

    // �ش� ������ � ������ �ѱ⸦ ����� �� ���� ���
    public GameObject[] gun;
    public GameObject[] ore;

    public AudioClip[] clip; // hitSound

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
        if (cnt <= 0)
        {
            if(gun != null)
            {
                int g = Random.Range(0, gun.Length + 1);
                if(g == gun.Length)
                {

                }
                else
                {
                    GameObject gg = Instantiate(gun[g], this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
                    gg.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 2, 1) * 100); // �����̳� �ѱⰡ ����ɶ� ������ �������� ƨ�ܳ����� // ���� ������ �������� �ٲܰ�

                }

            }
            int o = Random.Range(0, ore.Length);
            GameObject oo = Instantiate(ore[o], this.transform.position + new Vector3(-1, 0, 0), this.transform.rotation);
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
        int i = Random.Range(0,2);
        M_SoundManager.instance.SFXPlay("oreHit", clip[i]);
        isDamage = true;
        cnt--;
        mat.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mat.material.color = oriCol;
        isDamage = false;
    }
}
