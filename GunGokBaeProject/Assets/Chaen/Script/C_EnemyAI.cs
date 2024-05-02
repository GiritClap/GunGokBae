using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyAI : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Àû ÃßÀû
        if (other.tag == "Player")
        {
            Enemy.GetComponent<C_EnemyAttack>().target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Enemy.GetComponent<C_EnemyAttack>().target = null;
        }
    }
}
