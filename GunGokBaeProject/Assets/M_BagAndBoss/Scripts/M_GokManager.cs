using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GokManager : MonoBehaviour
{
    public M_Gok originalGok;
    public M_AttackGok attackGok;
    public M_DefenseGok defenseGok;
   
    public void ChooseAttackGok()
    {
        originalGok.enabled = false;
        defenseGok.enabled = false;
        attackGok.enabled = true;
    }

    public void ChooseDefenseGok()
    {
        originalGok.enabled = false;
        defenseGok.enabled = true;
        attackGok.enabled = false;
    }

    public void ResetToOriginalGok()
    {
        originalGok.enabled = true;
        defenseGok.enabled = false;
        attackGok.enabled = false;
    }
}
