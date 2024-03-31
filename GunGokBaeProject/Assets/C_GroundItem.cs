using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class C_GroundItem : MonoBehaviour
{
    [SerializeField] Text Text;
    private bool isTrigger;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            player.GetComponent<C_PlayerItem>().player_ItemNum[2] = player.GetComponent<C_PlayerItem>().special_gun[2];
            Debug.Log("ÃÑ º¯°æ ¿Ï·á");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.gameObject.SetActive(true);
            isTrigger = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.gameObject.SetActive(false);
            isTrigger = false;
            player = null;
        }
    }
}