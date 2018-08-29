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

    public AudioSource sfxKick, sfxShoot, sfxPunch, sfxDamage;
    public AudioSource sfxWin, sfxLose, sfxCorrect, sfxWrong;

    private int playerAnswer, startValue;

    public bool answeredCorrectly, answered;

    List<Animation> animations;
  

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
    Vector3 pos,origin;


	// Use this for initialization
	void Start () {
		currentState = TurnState.START;
        answeredCorrectly = false;
        anim = this.gameObject.GetComponent<Animator>();
        startTimer = false;
        timer = duration;
        pos = transform.position;
        origin = pos;
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

    public void attackAnim(Vector3 monster)
    {
        //Randomize between kickAnim, shootAnim or punchAnim randomize using Random.int(0,100)
        //Then divide the chances by 3
        //int attackprob = Random.Range(0, 100);

        /*if (attackprob >= 0 && attackprob < 33)
            kickAnim(monster);
        else if (attackprob >= 33 && attackprob < 66)
            shootAnim();
        else
            punchAnim(monster);

        this.anim.Play("Idle");
        */
        shootAnim();
    }

    private void kickAnim(Vector3 monster)
    {
        Debug.Log("Kicking!");
        Debug.Log("mecha old position before moving forward: " + pos);
        moveForwardAnim(monster);//Running/Walking forward animation
        //Move until near to the enemy

        Debug.Log("mecha new position after moving forward: "+ pos);
        this.anim.Play("Kick");

        //PLAY KICK SFX HERE
        sfxKick.Play();

        //Walk backward to original spot
        //moveBackwardAnim();//Walk backward to original spot
        Debug.Log("mecha new position after moving backward: " + pos);
        Debug.Log("mecha pos and origin: " + pos + " "+ origin);
        
    }

    private void moveForwardAnim(Vector3 monster)
    {


         while (pos.x < (monster.x - 2.5f))
         {
             //this.anim.SetTrigger("isMovingForward");
             this.anim.Play("MoveForward");

             
             transform.position = pos;
         }

   
    }

    public void moveBackwardAnim()
    {
        while (pos.x != origin.x)
        {
            this.anim.Play("MoveBackward");
            pos.x = pos.x - 0.50f;
            transform.position = pos;
        }  
    }

    private void shootAnim()
    {
        Debug.Log("Shooting!");
        //There should be Shooting state in the Player Animator
        this.anim.Play("ReadyShoot");//Shooting animation
        //PLAY SHOOT SFX HERE
        sfxShoot.Play();
    }

    private void punchAnim(Vector3 monster)
    {

        Debug.Log("Punching!");
        //while (pos.x < monster.x)
        moveForwardAnim(monster);//Running/Walking forward animation
        //Move until near to the enemy

        //Play punch animation
        //PLAY PUNCH SFX HERE
        sfxPunch.Play();
        //Walk backward to original spot

        Debug.Log("mecha new position after moving forward: " + pos);
        this.anim.Play("HookPunch");
        //PLAY KICK SFX HERE
        //moveBackwardAnim();//Walk backward to original spot
        Debug.Log("mecha new position after moving backward: " + pos);
        Debug.Log("mecha pos and origin: " + pos + " " + origin);
        //moveBackwardAnim();

    }

    public void damageAnim()
    {
        this.anim.Play("Damage");
        sfxDamage.Play();
    }

    public void winAnim()
    {
        this.anim.Play("Win");
        sfxWin.Play();
    }
    public void dieAnim()
    {
        this.anim.Play("Die");
        sfxLose.Play();
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
            sfxCorrect.Play();
        }
        else {
            Debug.Log("Wrong!");
            isCorrect = false;
            pb.wrong();
            //PLAY WRONG SOUND HERE
            sfxWrong.Play();
        }
        
        answeredCorrectly = isCorrect;
        startTimer = true;
    }
}
