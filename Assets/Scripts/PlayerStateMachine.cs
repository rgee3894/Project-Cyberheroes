using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

    public Player player = new Player();

    public enum TurnState
    {
        ANSWERING,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case (TurnState.ANSWERING):

            break;

            case (TurnState.WAITING):

            break;

            case (TurnState.ACTION):

            break;

            case (TurnState.DEAD):

            break;
        }

	}

    void UpgradeProgressBar(){

    }
}
