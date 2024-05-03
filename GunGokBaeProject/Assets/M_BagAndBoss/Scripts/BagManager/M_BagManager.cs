using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BagManager : MonoBehaviour
{
    private static M_BagManager instance;

    //광물 종류가 추가될때마다 stone변수 하나씩 추가
    public float stone = 0;
    public float stone2 = 0;
    public float stone3 = 0;
    public float stone4 = 0;
    public float stone5 = 0;

    //총 종류가 추가될때마다 gun변수 하나씩 추가
    public bool gun = false;
    public bool gun2 = false;
    public bool gun3 = false;
    public bool gun4 = false;
    public bool gun5 = false;


    private void Awake()
    {
        if(null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static M_BagManager Instance 
    {
        get 
        {
            if(null == instance)
            {
                return null;
            }
            return instance; 
        } 
    }


    // 아래에는 stone 추가
    public float GetStone()
    {
        return stone;
    }
    public void SetStone()
    {
        stone++;
    }

    public float GetStone2()
    {
        return stone2;
    }
    public void SetStone2()
    {
        stone2++;
    }

    public float GetStone3()
    {
        return stone3;
    }
    public void SetStone3()
    {
        stone3++;
    }

    public float GetStone4()
    {
        return stone4;
    }
    public void SetStone4()
    {
        stone4++;
    }

    public float GetStone5()
    {
        return stone5;
    }
    public void SetStone5()
    {
        stone5++;
    }

    // 아래에는 gun 추가

    public bool GetGun()
    {
        return gun;
    }
    public void SetGun(bool n)
    {
        gun = n;
    }

    public bool GetGun2()
    {
        return gun2;
    }
    public void SetGun2(bool n)
    {
        gun2 = n;
    }

    public bool GetGun3()
    {
        return gun3;
    }
    public void SetGun3(bool n)
    {
        gun3 = n;
    }

    public bool GetGun4()
    {
        return gun4;
    }
    public void SetGun4(bool n)
    {
        gun4 = n;
    }

    public bool GetGun5()
    {
        return gun5;
    }
    public void SetGun5(bool n)
    {
        gun5 = n;
    }
}
