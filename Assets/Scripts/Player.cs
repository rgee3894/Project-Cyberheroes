using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player{

    private int health;
    private string name;
    private int damage;

    public Player()
    {
        this.health = 200;
        this.damage = 0;
    }

    public int getDamage()
    {
        return this.damage;
    }

    private void takeDamage(Enemy monster)
    {
        this.health -= monster.getDamage();
    }

    public void attack(Enemy monster)
    {
        monster.takeDamage(this);
    }

}
