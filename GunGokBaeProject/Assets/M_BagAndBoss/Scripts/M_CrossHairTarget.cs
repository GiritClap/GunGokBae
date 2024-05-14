using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class M_CrossHairTarget : MonoBehaviour
{
    Camera mainCam;
    Ray ray;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCam.transform.position;
        ray.direction = mainCam.transform.forward;
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Enemy"));
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), hit, Mathf.Infinity, layerMask);
        Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, layerMask);
        transform.position = hitInfo.point;
    }
}
