using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Pattern1 : MonoBehaviour
{
    public GameObject pattern1_1;
    public GameObject pattern1_2;


    public float dangerTime = 0;
    public float upSpeed = 30;

    float timer = 0; 

    public AudioClip clip;
    bool isOneShot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpikeUp");
        timer += Time.deltaTime;
        if(timer > dangerTime && isOneShot)
        {
            M_SoundManager.instance.SFXPlay("Magma", clip);
            isOneShot = false;

        }
    }

    IEnumerator SpikeUp()
    {
        yield return new WaitForSeconds(dangerTime);
        pattern1_1.SetActive(false);
        pattern1_2.SetActive(true);

        pattern1_2.transform.Translate(Vector3.up * upSpeed * Time.deltaTime);

    }
}
