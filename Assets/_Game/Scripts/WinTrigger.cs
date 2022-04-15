using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader = null;
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] GameObject _winUI = null;

    void Start()
    {
        _winUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //detect if it's the player
        PlayerMovement _player = other.gameObject.GetComponent<PlayerMovement>();
        if (_player != null)
        {
            Debug.Log("Player entered Win Screen! :" + _player.name);

            //freeze player
            _player.frozen = true;

            //activate win UI Text
            _winUI.SetActive(true);

            //play sound
            AudioHelper.PlayClip2D(_winSound, .2f);
            
            // change scene
            StartCoroutine(StopBeforeLoad());
        }
    }

    IEnumerator StopBeforeLoad()
    {
        //wait for a bit
        yield return new WaitForSeconds(2f);

        //load main menu
        levelLoader.LoadNextLevel(0);
    }
}
