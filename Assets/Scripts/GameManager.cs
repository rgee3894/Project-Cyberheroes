using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool setupPhase, battlePhase;
    public GameObject setupPanel, battlePanel, winScreen, loseScreen;

    public PlayerStateMachine player; 
    public EnemyStateMachine enemy;

    private ProblemGenerator pg; 

    public SimpleHealthBar playerHealthBar;

    public SimpleHealthBar enemyHealthBar;


    private float timer;
    private float duration = 5.5f;
    private bool startTimer, battleFinished;

    // Use this for initialization
    void Start()
    {
        setupPhase = false;
        battlePhase = false;
        timer = duration;
        startTimer = false;
        battleFinished = false;
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

            if(!battleFinished) Battle();

            if(startTimer)//Time delay for the player to see the above animations going on
            {
                timer-=Time.deltaTime;
                if(timer <= 0.0f)
                {
                    startTimer = false;
                    timer = duration;

                    if(player.mecha.GetHealth() > 0)
                    {
                        if(enemy.monster.GetHealth() <= 0)
                        {
                            player.currentState = PlayerStateMachine.TurnState.WIN;
                            enemy.deathAnim();
                            player.winAnim();
                            winScreen.SetActive(true);
                        }
                        else
                        {
                            player.currentState = PlayerStateMachine.TurnState.ANSWERING;
                        }
                    }
                    else
                    {
                        player.dieAnim();
                        player.currentState = PlayerStateMachine.TurnState.DEAD;
                        loseScreen.SetActive(false);
                    }
                    battleFinished = false;
                }
                else{
                    player.currentState = PlayerStateMachine.TurnState.ACTION;
                }
            }
        }

        
        if(player.currentState == PlayerStateMachine.TurnState.ACTION)
        {
            setupPhase = false;
            battlePhase = true;
            startTimer = true;
        }
        else if(player.currentState == PlayerStateMachine.TurnState.ANSWERING)
        {
            setupPhase = true;
            battlePhase = false;
        }

    }

    private void Battle()
    {
        //Know distance of player and monter from one another
        Vector3 monster = GameObject.Find("Slime_Green").transform.position;
        Vector3 mecha = GameObject.Find("Mecha").transform.position;

        if (player.answeredCorrectly)
        {
            Debug.Log("Player attacks monster!");

            player.attackAnim(monster); //PERFORM PLAYER ATTACK ANIMATION HERE
            Debug.Log("Player attack animation!");
            player.mecha.Attack(enemy.monster);
           
            enemy.damageAnim();//PERFORM ENEMY HURT ANIMATION HERE
            Debug.Log("Monster damaged animation!");
            Debug.Log("Enemy Health: " + enemy.monster.GetHealth() + "/" + enemy.monster.GetMaxHealth());
            enemyHealthBar.UpdateBar(enemy.monster.GetHealth(), enemy.monster.GetMaxHealth());
                
        }
        else
        {   
            Debug.Log("Monster attacks player!");
            enemy.attackAnim(mecha);//PERFORM ENEMY ATTACK ANIMATION HERE
            Debug.Log("Monster attack animation!");
            player.mecha.TakeDamage(enemy.monster);
            player.damageAnim();//PERFORM PLAYER HURT ANIMATION HERE IF ANY
            Debug.Log("Player falls animation!");
            Debug.Log("Player Health: " + player.mecha.GetHealth() + "/" + player.mecha.GetMaxHealth());
            playerHealthBar.UpdateBar(player.mecha.GetHealth(), player.mecha.GetMaxHealth());
        }
        battleFinished = true;
        startTimer = true;
    }




}
