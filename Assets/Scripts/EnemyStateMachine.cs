using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {
    public Enemy monster = new Enemy();

    public AudioSource sfxAttack, sfxHurt, sfxDeath;

    private Animator anim;
    Vector3 pos,origin;

    public enum TurnState
    {
        WAITING,
        ATTACKING,
        TAKING_DAMAGE,
        DEAD,

        START
    }

    public TurnState currentState;

    // Use this for initialization
    void Start () {
        currentState = TurnState.START;
        anim = this.gameObject.GetComponent<Animator>();
        pos = transform.position;
        origin = pos;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        switch (currentState)
        {
            case (TurnState.WAITING):
                anim.Play("slime_idle");
                Debug.Log("Monster Idle");
                break;
            case (TurnState.ATTACKING):
                anim.Play("slime_attack");
                Debug.Log("Monster attack animation");
                break;
            case (TurnState.TAKING_DAMAGE):
                anim.Play("slime_damage");
                Debug.Log("Monster take damage animation");
                break;
            case (TurnState.DEAD):
                anim.Play("slime_die");
                Debug.Log("Monster death animation");
                break;
        } */
    }

    public void attackAnim(Vector3 mecha)
    {
        Debug.Log("monster new position after moving backward: " + pos);
        //Moving forward animation
        //Move until near to the enemy
        moveForwardAnim(mecha);
        this.anim.Play("Attack");
        Debug.Log("Monster attack animation");
        moveBackwardAnim();
        //PLAY MONSTER ATTACK SFX
        sfxAttack.Play();
        //Move backward to original spot
        Debug.Log("monster new position after moving backward: " + pos);
        Debug.Log("monster pos and origin: " + pos + " " + origin);
    }

    private void moveForwardAnim(Vector3 mecha)
    {


        while (pos.x > (mecha.x + 2.5f))
        {
            //this.anim.SetTrigger("isMovingForward");
            this.anim.Play("MoveForward");

            pos.x = pos.x - 0.50f;
            transform.position = pos;
        }


    }

    public void moveBackwardAnim()
    {


        while (pos.x != origin.x)
        {
            this.anim.Play("MoveBackwards");
            pos.x = pos.x + 0.50f;
            transform.position = pos;
        }


    }

    public void damageAnim()
    {
        this.anim.Play("Damage");
        sfxHurt.Play();
        Debug.Log("Monster attack animation");
    }

    public void deathAnim()
    {
        this.anim.Play("Die");
        sfxDeath.Play();
        Debug.Log("Monster attack animation");
    }


}
