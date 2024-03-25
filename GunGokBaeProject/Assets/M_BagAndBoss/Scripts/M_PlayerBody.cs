using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerBody : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "gun")
        {
            M_BagManager.Instance.SetGun(true);
            Destroy(collision.gameObject);
        }   
        if (collision.collider.tag == "gun2")
        {
            M_BagManager.Instance.SetGun2(true);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "gun3")
        {
            M_BagManager.Instance.SetGun3(true);
            Destroy(collision.gameObject);
        }




        if (collision.collider.tag == "stone")
        {
            M_BagManager.Instance.SetStone();
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone2")
        {
            M_BagManager.Instance.SetStone2();
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone3")
        {
            M_BagManager.Instance.SetStone3();
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone4")
        {
            M_BagManager.Instance.SetStone4();
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "stone5")
        {
            M_BagManager.Instance.SetStone5();
            Destroy(collision.gameObject);
        }


    }
}
