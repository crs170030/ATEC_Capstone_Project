using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicButton : MonoBehaviour
{
    public int buttonID = 0; //change in inspector
    [SerializeField] Text _spellName = null;
    [SerializeField] Text _spellDesc = null;
    [SerializeField] Text _spellCost = null;

    public void UpdateText(MagicBase magic)
    {
        _spellName.text = magic.SpellNames[buttonID];
        _spellDesc.text = magic.SpellDesc[buttonID];
        _spellCost.text = magic.SpellCost[buttonID] + "";
    }
}
