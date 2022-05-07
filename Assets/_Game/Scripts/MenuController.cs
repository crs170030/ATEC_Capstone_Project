using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader = null;
    [SerializeField] private PlayerPosSO playerSO = null;
    [SerializeField] private EnemiesKilledSO enemiesSO = null;
    [SerializeField] AudioClip _menuMusic = null;
    AudioSource audSauce = null;

    // Start is called before the first frame update
    void Start()
    {
        //play menu music
        if (_menuMusic != null)
        {
            audSauce = AudioHelper.PlayClip2D(_menuMusic, .6f);
        }
        //reset player's normal position
        playerSO.PlayerPosition = new Vector3(580f, 339.29f, 1131.4f);
        //give players full health
        playerSO.KazHealth = 100f;
        playerSO.PhoebeHealth = 100f;
        playerSO.MonchHealth = 100f;

        //reset enemies
        enemiesSO.EnemiesKilled = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            OnPressedConfirm();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPressedCancel();
        }
    }

    void OnPressedConfirm()
    {
        audSauce.Stop();

        Debug.Log("Loading next level!");
        if(levelLoader != null)
            levelLoader.LoadNextLevel(1);
    }

    void OnPressedCancel()
    {
        Application.Quit();
    }
}
