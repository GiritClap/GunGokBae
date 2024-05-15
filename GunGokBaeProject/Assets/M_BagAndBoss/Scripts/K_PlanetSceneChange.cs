using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class K_PlanetSceneChange : MonoBehaviour
{
    GameObject Spaceship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Spaceship")) {
            SceneManager.LoadScene("Shin_Map02 1");
        }
      
    }
}
