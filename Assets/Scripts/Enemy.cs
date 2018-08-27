using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemy{

    private int health;

    private int maxHealth;
    private int damage;


    public Enemy()
    {
        this.maxHealth = 200;
        this.health = maxHealth;
        this.damage = 20;
    }

    public void TakeDamage(Player hero)
    {
        this.health -= hero.GetDamage();
    }

    public int GetDamage()
    {
        return this.damage;
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
