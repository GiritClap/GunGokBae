using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CamRotate : MonoBehaviour
{

    /*    public float rotSpeed = 200;

        float mx;
        float my;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            mx += h * rotSpeed * Time.deltaTime;
            my += v * rotSpeed * Time.deltaTime;

            my = Mathf.Clamp(my, -90, 90);
            transform.eulerAngles = new Vector3(-my, mx, 0);
        }*/

    public float sensX;
    public float sensY;

    public Transform orientation;
    public GameObject playerObj;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        playerObj.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
