using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_ServerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("MyPlayer_Real", new Vector3(0, 3, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
