using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMonch : MagicBase
{
    //public int CapeFlipPower = 100;
    public float LoseHeadDefenseBuff = 80f;

    protected override void AssignValues()
    {
        SpellNames = new string[] { "Plague", "Lose Your Head" };
        SpellDesc = new string[] { "Infects enemy with the plague. (Infected: Lose resolve and health every turn)", "Reduce damage taken this turn by 80%. Enemies target you instead." };
        SpellCost = new int[] { 20, 30 };
    }

    public override void CastSpell(int spellID, List<HealthBase> TargetGroup = null)
    {
        switch (spellID)
        {
            default: // ID == 0
                //Plauge Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    EnemyResources er = target.GetComponent<EnemyResources>();

                    if (er != null)
                    {
                        Debug.Log("MagicMonch:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                            + " to infect them with the plague.");

                        er.hasStatusEffect = true;
                        er.isInfected = true;
                        //er.Infected.Invoke();
                        er.ChangeSprite(); //update enemy sprite on status conditon
                    }

                }
                break;

            case 1: // ID == 1
                // Lose Head Spell!
                foreach (HealthBase target in TargetGroup)
                {
                    Debug.Log("MagicMonch:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                        + " dealing " + LoseHeadDefenseBuff + " damage.");
                    //target.TakeDamage(SnackAttackPower);
                    
                }
                break;
        }
    }
}
