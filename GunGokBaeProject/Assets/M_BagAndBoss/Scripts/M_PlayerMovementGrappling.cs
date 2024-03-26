using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class M_PlayerMovementGrappling : MonoBehaviour
{

    /*[Header("Camera Effects")]
    public PlayerCam cam;
    public float grappleFov = 95f;*/


    Rigidbody rb;
    public bool freeze;
    public bool activeGrapple;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

      
    }

    private bool enableMovementOnNextTouch;
    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;

        velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
        Invoke(nameof(SetVelocity), 0.1f);

        Invoke(nameof(ResetRestrictions), 3f);
    }

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        enableMovementOnNextTouch = true;
        //rb.velocity = velocityToSet;
        rb.AddForce(velocityToSet);

        //cam.DoFov(grappleFov);
    }

    public void ResetRestrictions()
    {
        activeGrapple = false;
        //cam.DoFov(85f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enableMovementOnNextTouch)
        {
            enableMovementOnNextTouch = false;
            ResetRestrictions();

            GetComponent<M_Grappling>().StopGrapple();
        }
    }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }

}
