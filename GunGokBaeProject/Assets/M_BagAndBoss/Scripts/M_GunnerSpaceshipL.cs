using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GunnerSpaceshipL : MonoBehaviour
{
    public Transform spaceship;
    public Transform player;

    bool spaceshipDrive;

    [Header("Cameras")]
    public GameObject playerCam;
    public GameObject spaceshipCam;

    private void Start()
    {
        spaceshipDrive = false;


    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
        if (playerCam == null)
        {
            playerCam = GameObject.Find("PlayerCamera");
        }
        if (spaceship == null)
        {
            spaceship = GameObject.Find("Spaceship").transform;
            
        }
        if (spaceshipCam == null)
        {
            spaceshipCam = GameObject.Find("GunnerSpaceshipCameraL");
        }

        if (spaceshipDrive == false)
        {
            spaceshipCam.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && spaceshipDrive)
        {
          

            player.transform.parent.SetParent(spaceship);
            player.gameObject.SetActive(false);

            playerCam.gameObject.SetActive(false);
            spaceshipCam.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
        


            player.transform.parent.SetParent(null);
            player.gameObject.SetActive(true);

            playerCam.gameObject.SetActive(true);
            spaceshipCam.gameObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            player.transform.position = this.transform.position;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
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