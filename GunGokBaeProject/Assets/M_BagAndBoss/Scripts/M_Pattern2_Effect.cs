using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Pattern2_Effect : MonoBehaviour
{
    public GameObject touchEffect;

    private void OnCollisionEnter(Collision other)
    {

        touchEffect.SetActive(true);
        Destroy(this);

    }
}
