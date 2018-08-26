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

    public SimpleHealthBar playerHealthBar;

    public SimpleHealthBar enemyHealthBar;

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

            if(player.answeredCorrectly)
            {
                Debug.Log("Player attacks monster!");
                player.attackAnim(); //PERFORM PLAYER ATTACK ANIMATION HERE
                player.mecha.Attack(enemy.monster);
                //PERFORM ENEMY HURT ANIMATION HERE
                Debug.Log("Enemy Health: " + enemy.monster.GetHealth() + "/" + enemy.monster.GetMaxHealth());
                enemyHealthBar.UpdateBar(enemy.monster.GetHealth(), enemy.monster.GetMaxHealth());

            }
            else
            {   
                Debug.Log("Monster attacks player!");
                //PERFORM ENEMY ATTACK ANIMATION HERE
                player.mecha.TakeDamage(enemy.monster);
                //PERFORM PLAYER HURT ANIMATION HERE IF ANY
                Debug.Log("Player Health: " + player.mecha.GetHealth() + "/" + player.mecha.GetMaxHealth());
                playerHealthBar.UpdateBar(player.mecha.GetHealth(), player.mecha.GetMaxHealth());
            }

            //ADD A TIME DELAY HERE (Wait for a few seconds before proceeding to the below code)
            
            //PSEUDOCODE FOR WINNING AND LOSING
            /*
            if player health > 0
            {
                if monster health <= 0 {
                    PERFORM ENEMY DEATH ANIMATION
                    Show Win Screen
                }
                else
                {
                    player.currentState = PlayerStateMachine.TurnState.ANSWERING
                }
            }
            else
            {
                PERFORM PLAYER DEATH ANIMATION
                player.currentState = PlayerStateMachine.TurnState.DEAD
                Show Lose Screen
            }
             */

            //COMMENT THIS LINE OUT ONCE YOU'VE IMPLEMENTED THE ABOVE PSEUDOCODE
            player.currentState = PlayerStateMachine.TurnState.ANSWERING;

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
