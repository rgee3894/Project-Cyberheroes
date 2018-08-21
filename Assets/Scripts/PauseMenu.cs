using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource pauseSFX;
    public AudioSource resumeSFX;
	
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
    void Resume()
    {
        pauseSFX.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pause game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        resumeSFX.Play();
        Time.timeScale = 0f;            //freeze the game
        GameIsPaused = true;
    }
}
