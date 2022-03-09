using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBase : MonoBehaviour
{
    public static int spellCount = 2;
    public string[] SpellNames = new string[spellCount];
    public string[] SpellDesc = new string[spellCount];
    public int[] SpellCost = new int[spellCount];

    // Start is called before the first frame update
    void Start()
    {
        AssignValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void AssignValues()
    {
        SpellNames = new string[] { "Spell 1", "Spell 2" };
        SpellDesc = new string[] { "Casts Spell 1", "Casts Spell 2" };
        SpellCost = new int[] { 25, 35 };
    }

    public virtual void CastSpell(int spellID, HealthBase[] TargetGroup = null)
    {
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
    }
}
