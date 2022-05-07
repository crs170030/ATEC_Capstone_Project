using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimation : MonoBehaviour
{
    CharacterBase charBase;

    int oldAnimState = 0;

    [SerializeField] Image _charImage = null;

    [SerializeField] Sprite _normal = null;
    [SerializeField] Sprite _attack = null;
    [SerializeField] Sprite _magic = null;
    [SerializeField] Sprite _defend = null;
    [SerializeField] Sprite _hurt = null;
    [SerializeField] Sprite _dead = null;
    [SerializeField] Sprite _victory = null;

    // Start is called before the first frame update
    void Start()
    {
        charBase = GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oldAnimState != charBase.animationState)
        {
            //Debug.Log("updating "+ this + " sprite! From " + oldAnimState+ " to " + charBase.animationState);
            oldAnimState = charBase.animationState;

            ChangeImage();
        }
    }

    void ChangeImage()
    {
        switch (oldAnimState)
        {
            default: _charImage.sprite = _normal;
                break;

            case 1:
                _charImage.sprite = _attack;
                break;

            case 2:
                _charImage.sprite = _magic;
                break;

            case 3:
                _charImage.sprite = _defend;
                break;

            case 4:
                _charImage.sprite = _hurt;
                break;

            case 5:
                _charImage.sprite = _dead;
                break;

            case 6:
                _charImage.sprite = _victory;
                break;
        }
    }
}
