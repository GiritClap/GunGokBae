using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RaycastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    [Header("Pistol Hit Particle")]
    public ParticleSystem pistolMuzzleFlash;
    public ParticleSystem pistolHitEffect;
    public Transform pistolRaycastOrigin;
    
    [Header("Machinegun Hit Particle")]
    public ParticleSystem machinegunMuzzleFlash;
    public ParticleSystem machinegunHitEffect;
    public Transform machinegunRaycastOrigin;
    public TrailRenderer machinegunTracerEffet;

    [Header("Raycast Destination")]
    public Transform raycastDestination;

    Ray ray;
    RaycastHit hitInfo;

    public void StartPistolFiring()
    {
        isFiring = true;
        pistolMuzzleFlash.Play();

        ray.origin = pistolRaycastOrigin.position;
        ray.direction = raycastDestination.position - pistolRaycastOrigin.position;

        if(Physics.Raycast(ray, out hitInfo))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);
            pistolHitEffect.transform.position = hitInfo.point;
            pistolHitEffect.transform.forward = hitInfo.normal;
            pistolHitEffect.Emit(1);
        }
    }
    public void StopPistolFiring()
    {
        isFiring= false;
    }

    public void StartMachinegunFiring()
    {
        isFiring = true;
        machinegunMuzzleFlash.Play();

        ray.origin = machinegunRaycastOrigin.position;
        ray.direction = raycastDestination.position - machinegunRaycastOrigin.position;

        var tracer = Instantiate(machinegunTracerEffet, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);
            machinegunHitEffect.transform.position = hitInfo.point;
            machinegunHitEffect.transform.forward = hitInfo.normal;
            machinegunHitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;
        }
    }
    public void StopMachinegunFiring()
    {
        isFiring = false;
    }
}