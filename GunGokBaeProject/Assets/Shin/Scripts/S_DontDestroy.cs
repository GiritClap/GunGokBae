using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DontDestroy : MonoBehaviour
{
    private static S_DontDestroy instance;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static S_DontDestroy Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}
