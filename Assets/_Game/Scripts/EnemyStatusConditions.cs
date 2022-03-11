using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStatusConditions : MonoBehaviour
{
    public int infectionStrength = 20;

    

    public void ApplyStatusConditions(EnemyResources er)
    {
        if (er.hasStatusEffect)
        {
            if (er.isInfected)
            {
                er.ReduceResolve(infectionStrength);
                er.TakeDamage((float)infectionStrength);
            }
        }
    }
}
