using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RideSpaceship : MonoBehaviour
{
    public MonoBehaviour SpaceshipCon;
    public Transform spaceship;
    public Transform player;

    bool spaceshipDrive;

    [Header("Cameras")]
    public GameObject playerCam;
    public GameObject spaceshipCam;

    private void Start()
    {
        SpaceshipCon.enabled = false;
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("MyPlayer").transform;
        }
        if(playerCam == null)
        {
            playerCam = GameObject.Find("PlayerCamera");
        }
        if(Input.GetKeyDown(KeyCode.E) && spaceshipDrive)
        {
            SpaceshipCon.enabled = true;

            player.transform.SetParent(spaceship);
            player.gameObject.SetActive(false);

            playerCam.gameObject.SetActive(false);
            spaceshipCam.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            SpaceshipCon.enabled = false;

            player.transform.SetParent(null);
            player.gameObject.SetActive(true);

            playerCam.gameObject.SetActive(true);
            spaceshipCam.gameObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            spaceshipDrive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spaceshipDrive = false;
        }
    }
}
