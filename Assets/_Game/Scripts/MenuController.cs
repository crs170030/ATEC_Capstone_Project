using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader = null;
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
