using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCamera : MonoBehaviour {

	public GameManager gameManager; 
	public void StartGame()
	{
		gameManager.setupPanel.SetActive(true);
		gameManager.setupPhase = true;
		gameManager.battlePhase = false;
		gameManager.player.currentState = PlayerStateMachine.TurnState.ANSWERING;
		

	}
}
