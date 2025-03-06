using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public bool wantsettingsTimeLine = false;

    
    public GameObject settings_window;
    public PlayableDirector director;

    public float firsttimefortimeline = 0.37f;
    public float secondtimefortimeline = 0.63f;



    public void Awake()
    {
        Time.timeScale = 1;
        settings_window.SetActive(false);
    }

    public void LoadNextLevel()
    {
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIdx = currentSceneIdx + 1;

        if(nextSceneIdx == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIdx = 2;
        }
        SceneManager.LoadScene(nextSceneIdx);
    }

    public void Reload()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
            
    public void Settings()
    {
            settings_window.SetActive(true);
            Invoke("Pause", firsttimefortimeline);
    }
    public void CloseSettings()
    {
        Time.timeScale = 1;
        director.Play();
        Invoke("RestartButton", secondtimefortimeline);
    }
    public void Pause()
    {
        director.Pause();
        Time.timeScale = 0;
    }
    public void RestartButton()
    {
        settings_window.SetActive(false);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
