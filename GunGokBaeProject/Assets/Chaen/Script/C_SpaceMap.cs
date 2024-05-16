using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpaceMap : MonoBehaviour
{
    bool isTrigger = false;
    public GameObject spaceMap;

    bool isMap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isMap==false)
        {
            spaceMap.SetActive(true);
            isMap = true;
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Escape)) && isMap == true)
        {
            spaceMap.SetActive(false);
            isMap = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpaceMap") {
            isTrigger = true;
        }
    }
}
