using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Pattern2_Effect : MonoBehaviour
{
    public GameObject touchEffect;
    public AudioClip clip;
    private void OnCollisionEnter(Collision other)
    {
        M_SoundManager.instance.SFXPlay("Meteor_boom", clip);
        GameObject ggg = Instantiate(touchEffect, transform.position, Quaternion.identity);
        Destroy(ggg, 3f);
        Destroy(this);

    }
}
