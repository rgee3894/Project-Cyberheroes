using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemy{

    private int health;
    private int damage;


    public Enemy()
    {
        this.health = 200;
        this.damage = 20;
    }

    public void takeDamage(Player hero)
    {
        this.health -= hero.getDamage();
    }

    public int getDamage()
    {
        return this.damage;
    }

    public int getHealth()
    {
        return this.health;
    }
}
