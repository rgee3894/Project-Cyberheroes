using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {

    public Player mecha = new Player();

    private ProblemGenerator problemGenerator;

    public EnergyTank energyTank;

    public Slider answerSlider;

    public PowerBar pb;

    private int playerAnswer, startValue;

    public bool answeredCorrectly, answered;

    public enum TurnState
    {
        ANSWERING,
        WAITING,
        ACTION,
        DEAD,
        WIN,

        START
    }

    public TurnState currentState;

    public bool madeProblem;

    private Animator anim;

    private float timer; 
    private float duration = 0.5f;
    private bool startTimer;


	// Use this for initialization
	void Start () {
		currentState = TurnState.START;
        answeredCorrectly = false;
        anim = this.gameObject.GetComponent<Animator>();
        startTimer = false;
        timer = duration;
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            
            //During setup phase where the problem is made and shown to the player.
            case (TurnState.ANSWERING):
            answeredCorrectly = false;
            answered = false;
            pb.unanswered();
            if(!madeProblem)
            {
                makeProblem();
            }
            break;

            //During setup phase where the player answered. 
            //The energy tank animation occurs here and also checking of the answer.
            case (TurnState.WAITING):
            if(startValue != playerAnswer)//If the energy tank is not yet done
            {
                if(problemGenerator.IsMultiplication())
                    startValue++;
                else startValue--;

                energyTank.setValue(startValue);
            }
            else //If animating the energy tank is done
            {
                checkAnswer();//Check the answer

                if(startTimer)
                {
                    //Time delay here
                    timer -= Time.deltaTime;
                    if(timer <= 0.0f)
                    {
                        startTimer = false;
                        timer = duration;
                        madeProblem = false;
                        currentState = TurnState.ACTION; //This makes the GameManager go to Battle Phase
                        
                    }
                }
                
            }
            break;

            case (TurnState.ACTION):
            break;

            case (TurnState.DEAD):

            break;

            case (TurnState.WIN):
            break;

            case (TurnState.START):
            break;

            default:
            break;
        }

	}

    public void attackAnim()
    {
        //Randomize between kickAnim, shootAnim or punchAnim randomize using Random.int(0,100)
        //Then divide the chances by 3
        
    }

    private void kickAnim()
    {
        //Running/Walking forward animation
        //Move until near to the enemy
        this.anim.Play("Kick");
        //PLAY KICK SFX HERE
        //Walk backward to original spot
    }

    private void shootAnim()
    {
        //There should be Shooting state in the Player Animator
        //Shooting animation
        //PLAY SHOOT SFX HERE
    }

    private void punchAnim()
    {
        //There should be Punching state in the Player Animator
        //Move until near to the enemy
        //Play punch animation
        //PLAY PUNCH SFX HERE
        //Walk backward to original spot
    }

    public void damageAnim()
    {
        this.anim.Play("Damage");
    }

    public void winAnim()
    {
        this.anim.Play("Win");
    }
    public void dieAnim()
    {
        this.anim.Play("Die");
    }


    private void makeProblem()
    {
        problemGenerator = new ProblemGenerator();

        bool isMultiplicaton = problemGenerator.IsMultiplication();

        if(isMultiplicaton)
        {
            energyTank.setMin(problemGenerator.GetFirstOperand());
            energyTank.setMax(problemGenerator.GetAnswer());
            energyTank.setValue(problemGenerator.GetFirstOperand());
            energyTank.setupMultiplication();
        }
        else
        {
            energyTank.setMax(problemGenerator.GetFirstOperand());
            energyTank.setMin(problemGenerator.GetAnswer());
            energyTank.setValue(problemGenerator.GetFirstOperand());
            energyTank.setupDivision();
        }
        startValue = problemGenerator.GetFirstOperand();
        madeProblem = true;
        answerSlider.interactable = true;
    }

    public void answerProblem()
    {
        answerSlider.interactable = false;
        answered = true;
        int secondOperandAttempt = Mathf.RoundToInt(answerSlider.value);
        int firstOperand = problemGenerator.GetFirstOperand();
        if(problemGenerator.IsMultiplication()) {
            playerAnswer = firstOperand * secondOperandAttempt;
        }
        else {
            playerAnswer = firstOperand / secondOperandAttempt;
        }
        currentState = TurnState.WAITING;
    }

    public void checkAnswer()
    {
        bool isCorrect;
        if(playerAnswer == problemGenerator.GetAnswer()) {
            Debug.Log("Correct!");
            isCorrect =true;
            pb.correct();
            //PLAY CORRECT SOUND HERE
        }
        else {
            Debug.Log("Wrong!");
            isCorrect = false;
            pb.wrong();
            //PLAY WRONG SOUND HERE
        }
        
        answeredCorrectly = isCorrect;
        startTimer = true;
    }
}
