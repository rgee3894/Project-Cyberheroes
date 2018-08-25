using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour {

    public Player player = new Player();

    private ProblemGenerator problemGenerator;

    public EnergyTank energyTank;

    public Slider answerSlider;

    private int playerAnswer;

    public bool answeredCorrectly;

    public enum TurnState
    {
        ANSWERING,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

    private bool madeProblem;

	// Use this for initialization
	void Start () {
		currentState = TurnState.ANSWERING;
        answeredCorrectly = false;
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case (TurnState.ANSWERING):
            answeredCorrectly = false;
            if(!madeProblem)
            {
                makeProblem();
            }
            break;

            case (TurnState.WAITING):
            //PERFORM ANIMATING ENERGY TANK LEVEL HERE
            answeredCorrectly = checkAnswer();
            madeProblem = false;
            currentState = TurnState.ACTION;
            break;

            case (TurnState.ACTION):

            currentState = TurnState.ANSWERING;

            break;

            case (TurnState.DEAD):

            break;
        }

	}

    void UpgradeProgressBar(){

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
        madeProblem = true;
        answerSlider.interactable = true;
    }

    public void answerProblem()
    {
        answerSlider.interactable = false;

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

    public bool checkAnswer()
    {
        bool isCorrect;
        if(playerAnswer == problemGenerator.GetAnswer()) {
            Debug.Log("Correct!");
            isCorrect =true;
        }
        else {
            Debug.Log("Wrong!");
            isCorrect = false;
        }

        return isCorrect;
    }
}
