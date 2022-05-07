using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    [SerializeField] private EnemiesKilledSO enemiesSO = null;

    /*
    [SerializeField] LevelLoaderScript levelLoader = null;

    public void EnterBattleState()
    {
        levelLoader.LoadNextLevel(2);
    }
    */

    //idk what i used this script for, but ill use it to make sure enemies stay dead

    void Start()
    {
        GameObject target = null;

        foreach (string enemyName in enemiesSO.EnemiesKilled)
        {
            target = GameObject.Find(enemyName);

            if (target != null)
                Destroy(target);
        }
            /*
            EnemyMovement[] enemyObs = FindObjectsOfType<EnemyMovement>();

            foreach (string enemyName in enemiesSO.EnemiesKilled)
            {
                foreach (EnemyMovement enemy in enemyObs)
                {
                    Debug.Log("enemyID: " + enemyName);

                    if (string.Equals(enemyName, enemy.gameObject.name))
                    {
                        Debug.Log("Enemy moving no more! ID:" + enemy.gameObject.name);
                        Destroy(enemy);
                    }
                }
            }
            */
        }
}
