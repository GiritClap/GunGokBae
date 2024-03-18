using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BossCheckPlayer : MonoBehaviour
{
    string log = "�÷��̾� �߰�";

    bool checkPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log(log);
            checkPlayer = true;
        }
        else
        {
            checkPlayer = false;
        }
    }

    public bool GetCheckPlayer()
    {
        return checkPlayer;
    }

    
}
