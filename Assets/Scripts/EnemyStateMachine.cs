using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {
    public Enemy monster = new Enemy();
    private Animator anim;

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

    public void attackAnim()
    {
        this.anim.Play("Attack");
        Debug.Log("Monster attack animation");
    }

    public void damageAnim()
    {
        this.anim.Play("Damage");
        Debug.Log("Monster attack animation");
    }

    public void deathAnim()
    {
        this.anim.Play("Die");
        Debug.Log("Monster attack animation");
    }


}
