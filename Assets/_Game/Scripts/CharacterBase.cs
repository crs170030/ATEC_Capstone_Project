using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour, ICharacterCommand
{
    //[SerializeField] Image _charImage = null;
    //[SerializeField] Sprite _normalArt = null;
    //[SerializeField] Sprite _deadArt = null;
    public string _attackPlan = "none";
    public float baseDamage = 25;
    public float spellCost = 25;
    public float spellDamage = 50;
    public bool alive = true;
    public bool defending = false;
    public int chosenSpellID = 0;
    public float defense = 3;
    //float mana = 0;
    //float maxMana = 50;
    //public HealthBase[] TargetGroup = null;
    public List<HealthBase> TargetGroup = new List<HealthBase>();
    public MagicBase charMagic = null;
    //ref to change state machine tracker

    public int animationState = 0;
    //Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animationState = 0;
        _attackPlan = "none";
        charMagic = GetComponent<MagicBase>();

        //animator = GetComponent<Animator>();
    }

    /*
    void Update()
    {
        //make sure character animator has correct state num
        if (animator != null)
        {
            if (animator.GetInteger("CharacterState") != animationState)
                Debug.Log(this + " updating CharacterState from "+ animator.GetInteger("CharacterState") + " to " + animationState);

            animator.SetInteger("CharacterState", animationState);
        }
    }
    */

    public void SetAction(string attackPlan)
    {
        _attackPlan = attackPlan;
    }

    public void ResetAction()
    {
        _attackPlan = "none";
    }

    public void BaseAttack()
    {
        animationState = 1;
        //apply base Damage to list of targets
        if (TargetGroup != null)
        {
            foreach (HealthBase target in TargetGroup)
            {
                Debug.Log(this.name + " deals " + baseDamage + " damage to " + target);
                target.TakeDamage(baseDamage);
            }

            HealthBase hb = GetComponent<HealthBase>();
            hb.restoreHealth(baseDamage * 1.5f);

            ClearTargets();
        }
        else
        {
            Debug.Log(this.name + " target's group is null!");
        }
    }

    public void MagicAttack()
    {
        animationState = 2;

        //takes list of targets and applies effects to them
        //each character needs a different spell, use switch statement on parent name?
        if(charMagic != null)
        {
            charMagic.CastSpell(chosenSpellID, TargetGroup);
        }
        else
        {
            //TEMPORARY MAGIC SPELL
            Debug.Log("ERROR: " + this.name + " has to cast a default spell!");
            foreach (HealthBase target in TargetGroup)
            {
                Debug.Log(this.name + " uses " + spellCost + " mana to cast a spell on " + target
                    + " dealing " + spellDamage + " damage.");
                target.TakeDamage(spellDamage);
            }
        }

        ClearTargets();
    }

    public void AddTarget(HealthBase target)
    {
        ClearTargets();
        TargetGroup.Add(target);
        //TargetGroup = new HealthBase[1];
        //TargetGroup[0] = target;
    }

    public void AddTargets(HealthBase target)
    {
        /*
        int currentSize = TargetGroup.Length;
        HealthBase[] tempTargetGroup = TargetGroup;
        TargetGroup = new HealthBase[currentSize];
        TargetGroup = tempTargetGroup;
        TargetGroup[currentSize - 1] = target;
        */
        TargetGroup.Add(target);
        //Debug.Log(TargetGroup);
    }

    void ClearTargets()
    {
        TargetGroup.Clear();
        //TargetGroup = null;
    }

    public void ToggleAppearance()
    {
        //change sprite if the player is dead
        if (alive)
        {
            animationState = 0;
            /*
            if (_charImage != null && _normalArt != null)
                _charImage.sprite = _normalArt;
                */
        }
        else
        {
            animationState = 5;
            /*
            if (_charImage != null && _deadArt != null)
                _charImage.sprite = _deadArt;
                */
        }
    }

    public void Die(bool kill = true)
    {
        if (kill)
        {
            Debug.Log("Player " + this.name + " has fallen!");
            alive = false;
            //state machine already looks for character death event, it should update
        }
        else
        {
            alive = true;
        }
        ToggleAppearance();
    }
}
