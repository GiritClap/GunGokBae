using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RandomCubes : MonoBehaviour
{
    public GameObject cubes;
    float blockCnt = 300f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < blockCnt; i++)
        {
            float x = Random.Range(-500, 500);
            float y = Random.Range(-500, 500);
            float z = Random.Range(-500, 500);
            GameObject cb = Instantiate(cubes, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }
}
