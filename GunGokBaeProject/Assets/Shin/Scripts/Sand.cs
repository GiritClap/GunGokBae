using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    public static Sand instance;
    void Awake(){
        instance = this;
    }
    
    public float sandWalk = 30f;
    public float sandrRun = 50f;
}
