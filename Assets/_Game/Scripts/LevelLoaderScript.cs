using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 2f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
        */
    }

    public void LoadNextLevel(int levelIndex = -1)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(levelIndex == -1)
            StartCoroutine(SlowLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else
            StartCoroutine(SlowLoadLevel(levelIndex));
    }

    IEnumerator SlowLoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
