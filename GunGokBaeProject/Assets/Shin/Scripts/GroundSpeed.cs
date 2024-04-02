using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpeed : MonoBehaviour
{

    public float walkSpeed = 0.0f;
    public float runSpeed = 0.0f;

    void OnCollisionEnter(Collision coll){

        if(coll.collider.CompareTag("Ground_Sand")){
            walkSpeed = Sand.instance.sandWalk;
            runSpeed = Sand.instance.sandrRun;
            Debug.Log("무슨 땅? : Sand" );
        }
        else if(coll.collider.CompareTag("Ground")){
            walkSpeed = Ground.instance.groundWalk;
            runSpeed = Ground.instance.groundRun;
            Debug.Log("무슨 땅? : Ground");
        }
        

    }


}
