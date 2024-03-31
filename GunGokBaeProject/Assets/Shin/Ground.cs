using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static Ground instance;
    void Awake(){
        instance = this;
    }
    
    public float groundWalk = 70f;
    public float groundRun = 100f;

    
}
