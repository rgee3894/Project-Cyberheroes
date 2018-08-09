using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string nextLevel;
	public AudioClip musicClip;
	public AudioSource musicSource;

	void start() {
		musicSource.clip = musicClip;
		musicClip.Play();
	}

	public void PlayGame() {
		Application.LoadLevel(nextLevel);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
