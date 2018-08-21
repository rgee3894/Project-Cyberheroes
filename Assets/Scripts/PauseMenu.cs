using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource pauseSFX;
    public AudioSource bgMusic;
    public string mainMenuLevel;
    public string currentLevel;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    // Resume current game
    public void Resume()
    {
        bgMusic.volume *= 2.0f;
        pauseSFX.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pause game
    public void Pause()
    {
        bgMusic.volume *= 0.5f;
        pauseMenuUI.SetActive(true);
        pauseSFX.Play();
        Time.timeScale = 0f;            //freeze the game
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
    }
}
