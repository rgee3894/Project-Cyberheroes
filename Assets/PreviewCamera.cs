using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCamera : MonoBehaviour {

	public GameManager gameManager; 
	public void StartGame()
	{
		gameManager.setupPhase = true;
		gameManager.battlePhase = false;

	}
}
