﻿using System.Collections;
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
        SpellCost = new int[] { 20, 35 };
    }

    public override void CastSpell(int spellID, HealthBase[] TargetGroup = null)
    {
        /*
        int spellDamage = 75;
        //takes list of targets and applies effects to them
        //each character needs a different spell, use switch statement on parent name?
        foreach (HealthBase target in TargetGroup)
        {
            Debug.Log(this.name + " uses " + SpellCost[spellID] + " mana to cast a spell on " + target
                + " dealing " + spellDamage + " damage.");
            target.TakeDamage(spellDamage);
        }
        //in characterbase (from where its called), make sure to clear Targets
        */

        switch (spellID)
        {
            default: // ID == 0
                //Cape Flip Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    EnemyResources er = target.GetComponent<EnemyResources>();

                    if (er != null)
                    {
                        Debug.Log(this.name + " uses " + SpellCost[spellID] + " health to cast a spell on " + target
                            + " to scare them for " + CapeFlipPower + " resolve.");
                        er.ReduceResolve(CapeFlipPower);
                    }
                    
                }
                break;

            case 1: // ID == 1
                // Snack Attack Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    Debug.Log(this.name + " uses " + SpellCost[spellID] + " health to bite a spell on " + target
                        + " dealing " + SnackAttackPower + " damage.");
                    target.TakeDamage(SnackAttackPower);
                    //TODO: Add health recovery for all alive players??
                }
                break;
        }
    }
}