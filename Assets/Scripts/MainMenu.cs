using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string nextLevel;

	public void PlayGame() {
		Application.LoadLevel(nextLevel);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
