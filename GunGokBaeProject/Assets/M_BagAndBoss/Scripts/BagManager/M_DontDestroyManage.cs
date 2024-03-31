using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_DontDestroyManage : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
