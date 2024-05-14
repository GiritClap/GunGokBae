using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RandomCubes : MonoBehaviour
{
    float blockCnt = 300f;

    public GameObject[] obs;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < blockCnt; i++)
        {
            int aaa = Random.Range(0, 7);
            float x = Random.Range(-5000, 5000);
            float y = Random.Range(-5000, 5000);
            float z = Random.Range(-5000, 5000);
            GameObject cb = Instantiate(obs[aaa], new Vector3(x, y, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }
}
