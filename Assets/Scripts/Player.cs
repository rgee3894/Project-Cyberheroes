using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player{

    private int health;
    private string name;
    private int damage;

    private int maxHealth;


    public Player()
    {
        maxHealth = 200;
        this.health = this.maxHealth;
        damage = 40;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public void TakeDamage(Enemy monster)
    {
        this.health -= monster.GetDamage();
    }

    public void Attack(Enemy monster)
    {
        monster.TakeDamage(this);
    }

    public int GetHealth()
    {
        return this.health;
    }

    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

}
