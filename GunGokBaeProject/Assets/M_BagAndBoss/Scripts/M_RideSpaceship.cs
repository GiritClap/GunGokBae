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
        spaceshipDrive = false;
        if (SpaceshipCon == null)
        {
            SpaceshipCon = GameObject.Find("Spaceship").GetComponent<M_ShipController>();
            SpaceshipCon.enabled = false;
        }
        else
        {
            return;
        }



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
            SpaceshipCon = GameObject.Find("Spaceship").GetComponent<M_ShipController>();
            SpaceshipCon.enabled = false;
        }
        if (spaceshipCam == null)
        {
            spaceshipCam = GameObject.Find("RiderSpaceshipCamera");
        }

        if (spaceshipDrive == false)
        {
            spaceshipCam.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && spaceshipDrive)
        {
            SpaceshipCon.enabled = true;

            player.transform.parent.SetParent(spaceship);
            player.gameObject.SetActive(false);

            playerCam.gameObject.SetActive(false);
            spaceshipCam.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {

       

            SpaceshipCon.enabled = false;

            player.transform.parent.SetParent(null);
            player.gameObject.SetActive(true);

            playerCam.gameObject.SetActive(true);
            spaceshipCam.gameObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Vector3 ori
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