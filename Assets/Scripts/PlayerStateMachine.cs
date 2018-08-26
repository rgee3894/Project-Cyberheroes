using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {

    public Player player = new Player();

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

        START
    }

    public TurnState currentState;

    public bool madeProblem;


	// Use this for initialization
	void Start () {
		currentState = TurnState.START;
        answeredCorrectly = false;
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case (TurnState.ANSWERING):
            answeredCorrectly = false;
            answered = false;
            pb.unanswered();
            if(!madeProblem)
            {
                makeProblem();
            }
            break;

            case (TurnState.WAITING):
            if(startValue != playerAnswer)
            {
                if(problemGenerator.IsMultiplication())
                    startValue++;
                else startValue--;

                energyTank.setValue(startValue);
            }
            else
            {

                checkAnswer();

                madeProblem = false;
                currentState = TurnState.ACTION;
            }


            break;

            case (TurnState.ACTION):
            break;

            case (TurnState.DEAD):

            break;

            default:
            break;
        }

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
        }
        else {
            Debug.Log("Wrong!");
            isCorrect = false;
            pb.wrong();
        }
        
        answeredCorrectly = isCorrect;
    }

    IEnumerator Wait(float duration)
    {
        //This is a coroutine
       Debug.Log("Start Wait() function. The time is: "+Time.time);
        Debug.Log( "Float duration = "+duration);
         yield return new WaitForSeconds(duration);   //Wait
        Debug.Log("End Wait() function and the time is: "+Time.time);
    }
}
