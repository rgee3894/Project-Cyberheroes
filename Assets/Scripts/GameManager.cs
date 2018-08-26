using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool setupPhase, battlePhase;
    public GameObject setupPanel, battlePanel;

    public PlayerStateMachine player; 
    public EnemyStateMachine enemy;

    private ProblemGenerator pg; 

    // Use this for initialization
    void Start()
    {
        setupPhase = false;
        battlePhase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (setupPhase)
        {
            setupPanel.SetActive(true);
            battlePanel.SetActive(false);
            
        }
        else if(battlePhase)
        {
            
            setupPanel.SetActive(false);
            battlePanel.SetActive(true);

            //If player answered correctly, player attack monster (player.player.attack(enemy.monster);)
            //else, monster attack player

            //if player health > 0
            ////if monster health <= 0, Show win screen.
            ////else change state to ANSWERING
            //else Change state to DEAD. Show lose screen.

            //player.currentState = PlayerStateMachine.TurnState.ANSWERING;

        }

        
        if(player.currentState == PlayerStateMachine.TurnState.ACTION)
        {
            setupPhase = false;
            battlePhase = true; 
        }
        else if(player.currentState == PlayerStateMachine.TurnState.ANSWERING)
        {
            setupPhase = true;
            battlePhase = false;
        }
        
        

    }

    

}
