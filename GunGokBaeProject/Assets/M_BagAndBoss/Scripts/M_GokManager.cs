using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GokManager : MonoBehaviour
{
    public M_Gok originalGok;
    public M_SpeedGok speedGok;
    public M_DefenseGok defenseGok;
   
    public void ChooseSpeedGok()
    {
        originalGok.enabled = false;
        defenseGok.enabled = false;
        speedGok.enabled = true;
    }

    public void ChooseDefenseGok()
    {
        originalGok.enabled = false;
        defenseGok.enabled = true;
        speedGok.enabled = false;
    }

    public void ResetToOriginalGok()
    {
        originalGok.enabled = true;
        defenseGok.enabled = false;
        speedGok.enabled = false;
    }
}
