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

    /*
    [SerializeField] LevelLoaderScript levelLoader = null;

    public void EnterBattleState()
    {
        levelLoader.LoadNextLevel(2);
    }
    */
}
