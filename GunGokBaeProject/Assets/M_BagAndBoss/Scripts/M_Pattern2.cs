using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Pattern2 : MonoBehaviour
{
    public GameObject pattern2_1; // 바닥에 위험표시
    public GameObject pattern2_2; // 운석

    public float dangerTime = 0;
    public float upSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpikeDown");
    }

    IEnumerator SpikeDown()
    {
        yield return new WaitForSeconds(dangerTime);
        pattern2_1.SetActive(false);
        pattern2_2.SetActive(true);

        pattern2_2.transform.Translate(Vector3.down * upSpeed * Time.deltaTime);
    }
}
