using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinState : BattleState
{
    [SerializeField] Text _winTextUI = null;
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] private PlayerPosSO playerSO = null;
    //AudioSource audSauce = null;

    MagicKasimir kaz;
    MagicPhoebe pho;
    MagicMonch mon;

    HealthBase kazHB;
    HealthBase phoHB;
    HealthBase monHB;

    public override void Enter()
    {
        //Debug.Log("Win State: ...Entering");
        if (_winTextUI != null)
            _winTextUI.gameObject.SetActive(true);

        //try to stop audio and play tune
        //audSauce = AudioHelper.PlayClip2D(_winSound, 1f);
        //audSauce.Stop();
        AudioHelper.PlayClip2D(_winSound, 1f);

        ChangePlayerSprites();

        //hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        if (_winTextUI != null)
            _winTextUI.gameObject.SetActive(false);
        //unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        //Debug.Log("Win State: Exiting to Main Menu...");
    }

    void ChangePlayerSprites()
    {
        CharacterBase[] players = FindObjectsOfType<CharacterBase>();
        foreach (CharacterBase cb in players)
        {
            if(cb.alive)
                cb.animationState = 6;
        }
    }

    void SavePlayerHealth()
    {
        kaz = FindObjectOfType<MagicKasimir>();
        pho = FindObjectOfType<MagicPhoebe>();
        mon = FindObjectOfType<MagicMonch>();

        if (kaz != null && pho != null && mon != null)
        {
            kazHB = kaz.GetComponent<HealthBase>();
            phoHB = pho.GetComponent<HealthBase>();
            monHB = mon.GetComponent<HealthBase>();

            //save all character health!

            playerSO.KazHealth = kazHB.currentHealth;
            
            playerSO.PhoebeHealth = phoHB.currentHealth;
           
            playerSO.MonchHealth = monHB.currentHealth;
        }
    }

    void OnPressedConfirm()
    {
        //Debug.Log("Attempt to Enter Player Attack State!");
        //change to player attack state
        //StateMachine.ChangeState(StateMachine.MainMenu);

        SavePlayerHealth();


        //reload scene!
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene(1);
    }
}
