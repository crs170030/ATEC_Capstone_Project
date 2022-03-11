using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKasimir : MagicBase
{
    public int CapeFlipPower = 100;
    public float SnackAttackPower = 50f;

    protected override void AssignValues()
    {
        SpellNames = new string[] { "Cape Flip", "Snack Attack" };
        SpellDesc = new string[] { "Scares 1 Enemy.", "Heavily Damage 1 Enemy." };
        SpellCost = new int[] { 25, 40 };
    }

    public override void CastSpell(int spellID, List<HealthBase> TargetGroup = null)
    {
        switch (spellID)
        {
            default: // ID == 0
                //Cape Flip Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    EnemyResources er = target.GetComponent<EnemyResources>();

                    if (er != null)
                    {
                        Debug.Log("MagicKasimir:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                            + " to scare them for " + CapeFlipPower + " resolve.");
                        er.ReduceResolve(CapeFlipPower);
                    }
                    
                }
                break;

            case 1: // ID == 1
                // Snack Attack Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    Debug.Log("MagicKasimir:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                        + " dealing " + SnackAttackPower + " damage.");
                    target.TakeDamage(SnackAttackPower);
                    //TODO: Add health recovery for all alive players??
                }
                break;
        }
    }
}
