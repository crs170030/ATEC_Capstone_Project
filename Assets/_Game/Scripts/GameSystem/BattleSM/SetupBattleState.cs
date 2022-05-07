using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBattleState : BattleState
{
    [SerializeField] Transform UIGroup = null;
    [SerializeField] int _numberOfEnemies = 3;
    [SerializeField] EnemyBase enemyPrefab = null;
    [SerializeField] private PlayerPosSO playerSO = null;
    /*
    [SerializeField] CharacterBase char1 = null;
    [SerializeField] CharacterBase char2 = null;
    [SerializeField] CharacterBase char3 = null;
    */
    //[SerializeField] float _playerStartHealth = 100;

    float enemyStartSpawnY = Screen.height - Screen.height/6;
    float enemySpacing = Screen.height/4.5f;
    
    //float playerX = -600;
    float enemyX = Screen.width - Screen.width/5;
    bool _activated = false;

    MagicKasimir kaz;
    MagicPhoebe pho;
    MagicMonch mon;

    HealthBase kazHB;
    HealthBase phoHB;
    HealthBase monHB;

    public override void Enter()
    {
        //Debug.Log("Setup: ...Entering");
        //Debug.Log("Starting a battle with " + _numberOfEnemies + " enemies.");
        StateMachine.enemiesLeft = _numberOfEnemies;
        StateMachine.BattleUI.SetActive(true);

        //make sure enemy has correct screen height
        enemyStartSpawnY = Screen.height - Screen.height / 6;
        enemySpacing = Screen.height / 4.5f;
        enemyX = Screen.width - Screen.width / 5;
        //Debug.Log("enemy X ==" + enemyX);
        //Debug.Log("enemy Y ==" + enemyStartSpawnY + " screen height == " + Screen.height);
        SpawnCharacters();
        /*
        //restore health of all
        var entities = FindObjectsOfType<HealthBase>();
        foreach (HealthBase hb in entities)
        {
            hb.restoreHealth();
        }
        */
        //set player health to each character
        

        //Cant change state while in Enter or Exit
        //don't but change state here
        _activated = false;
    }

    public override void Tick()
    {
        StateDuration += Time.deltaTime;
        //bad method: makes delays
        if (_activated == false)
        {
            SetPlayerHealth();
            _activated = true;
            StateMachine.ChangeState(StateMachine.PlanState);
            //Debug.Log("Setup: ...Updating...");
        }
        //Debug.Log("Setup: ...Updating...");
    }

    public override void Exit()
    {
        _activated = false;
        //Debug.Log("Setup: Exiting...");
    }

    void SpawnCharacters()
    {
        //delete all enemies before creating new ones!
        var enemies = FindObjectsOfType<EnemyBase>();
        foreach(EnemyBase en in enemies){
            Destroy(en);
        }

        //spawn enemies
        var spawnY = enemyStartSpawnY;
        var spawnPosition = new Vector3(0, 0, 0);//Vector3(playerX, spawnY, 0);
        var offsetX = 0;

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            if (i % 2 == 0)
                offsetX = 100; //enemies are pushed to the right
            else
                offsetX = 0;

            spawnPosition = new Vector3(enemyX - offsetX, spawnY, 0);
            //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, UIGroup);
            var inst = Instantiate(enemyPrefab, UIGroup);
            inst.transform.position = spawnPosition;
            spawnY -= enemySpacing;
            //move enemy to back of UI
            inst.transform.SetAsFirstSibling();
        }
    }

    void SetPlayerHealth()
    {
        kaz = FindObjectOfType<MagicKasimir>();
        pho = FindObjectOfType<MagicPhoebe>();
        mon = FindObjectOfType<MagicMonch>();

        if (kaz != null && pho != null && mon != null)
        {
            kazHB = kaz.GetComponent<HealthBase>();
            phoHB = pho.GetComponent<HealthBase>();
            monHB = mon.GetComponent<HealthBase>();

            kazHB.ReduceHealth(100 - playerSO.KazHealth);
            phoHB.ReduceHealth(100 - playerSO.PhoebeHealth);
            monHB.ReduceHealth(100 - playerSO.MonchHealth);
            //set all character health!
            /*
            kazHB.currentHealth = playerSO.KazHealth;
            phoHB.currentHealth = playerSO.PhoebeHealth;
            monHB.currentHealth = playerSO.MonchHealth;
            */
        }
        else
        {
            Debug.Log("Setup Battle State: ERROR! Player health base not found!");
        }
    }
}
