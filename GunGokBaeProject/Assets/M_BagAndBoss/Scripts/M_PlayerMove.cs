using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerMove : MonoBehaviour
{
 

    private GameObject uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIs");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            uiManager.SetActive(true);
        }
        else
        {
            uiManager.SetActive(false);
        }

       
    }


 




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "stone")
        {
            M_BagManager.Instance.SetStone();
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "gun")
        {
            M_BagManager.Instance.SetGun(true);
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "stone2")
        {
            M_BagManager.Instance.SetStone2();
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "gun2")
        {
            M_BagManager.Instance.SetGun2(true);
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "stone3")
        {
            M_BagManager.Instance.SetStone3();
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "gun3")
        {
            M_BagManager.Instance.SetGun3(true);
            Destroy(collision.gameObject);
        }

    }
}
