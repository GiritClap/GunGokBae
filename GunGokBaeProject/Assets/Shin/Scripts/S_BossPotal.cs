using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S_BossPotal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
            SceneManager.LoadScene("Shin_BossScene");
  
    }
}
