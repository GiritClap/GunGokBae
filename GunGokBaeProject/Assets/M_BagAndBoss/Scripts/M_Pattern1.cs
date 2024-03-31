using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Pattern1 : MonoBehaviour
{
    public GameObject pattern1_1;
    public GameObject pattern1_2;

    public float dangerTime = 0;
    public float upSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpikeUp");
    }

    IEnumerator SpikeUp()
    {
        yield return new WaitForSeconds(dangerTime);
        pattern1_1.SetActive(false);
        pattern1_2.SetActive(true);
        pattern1_2.transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
    }
}
