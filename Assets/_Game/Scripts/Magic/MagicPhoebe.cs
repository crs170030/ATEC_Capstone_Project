using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPhoebe : MagicBase
{
    public int AllBarkPower = 100;
    public float AllBitePower = 30f;
    EnemyBase[] allEnemies;
    CharacterBase charBase;

    protected override void AssignValues()
    {
        SpellNames = new string[] { "All Bark", "All Bite" };
        SpellDesc = new string[] { "Scares all enemies.", "Chomp at one enemy, hurt others for a bit." };
        SpellCost = new int[] { 30, 40 };
    }

    public override void CastSpell(int spellID, List<HealthBase> TargetGroup = null)
    {
        switch (spellID)
        {
            default: // ID == 0
                //All Bark Spell!
                allEnemies = FindObjectsOfType<EnemyBase>();
                charBase = GetComponent<CharacterBase>();
                foreach(EnemyBase enemy in allEnemies)
                {
                    /*
                    if(enemy.GetInstanceID() != TargetGroup[0].GetInstanceID())
                    {
                        HealthBase enemyHB = enemy.GetComponent<HealthBase>();
                        charBase.AddTargets(enemyHB);
                    }*/
                    HealthBase enemyHB = enemy.GetComponent<HealthBase>();
                    if (!TargetGroup.Contains(enemyHB))
                    {
                        charBase.AddTargets(enemyHB);
                    }
                }

                foreach (HealthBase target in TargetGroup)
                {
                    EnemyResources er = target.GetComponent<EnemyResources>();

                    if (er != null)
                    {
                        Debug.Log("MagicPhoebe:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                            + " to scare them for " + AllBarkPower + " resolve.");
                        er.ReduceResolve(AllBarkPower);
                    }

                }
                break;

            case 1: // ID == 1
                // All Bite Spell!
                allEnemies = FindObjectsOfType<EnemyBase>();
                charBase = GetComponent<CharacterBase>();
                foreach (EnemyBase enemy in allEnemies)
                {
                    HealthBase enemyHB = enemy.GetComponent<HealthBase>();
                    if (!TargetGroup.Contains(enemyHB))
                    {
                        charBase.AddTargets(enemyHB);
                    }
                }

                int enemynum = 0;
                float thisBitePower = AllBitePower;
                foreach (HealthBase target in TargetGroup)
                {
                    if (enemynum != 0)
                        thisBitePower = AllBitePower / 2; //deal half damage to all those except primary target

                    Debug.Log("MagicPhoebe:" + this.name + " uses " + SpellCost[spellID] + " health to cast " + SpellNames[spellID] + " on " + target
                        + " dealing " + thisBitePower + " damage.");
                    target.TakeDamage(thisBitePower);
                    enemynum += 1;
                }
                break;
        }
    }
}
