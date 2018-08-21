using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string nextLevel;
	public AudioSource musicSource;

	void start() {
        if(musicSource != null)
            musicSource.Play();
	}

	public void PlayGame() {
		Application.LoadLevel(nextLevel);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
