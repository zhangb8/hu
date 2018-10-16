using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {
    public int maxHealth;
    public int health;
    public int dmg;
    public int heal;

    public override void Interact()
    {
        print("interacting w/ enemy");
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);
        GameManager.loadBattle();
    }

    public void takeDamage(int dmg)
    {
        if (health - dmg < 0)
        {
            health = 0;
        }
        else
        {
            health -= dmg;
        }
    }

    public void Heal(int heal)
    {
        if (health + heal > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += heal;
        }
    }

    public string Move()
    {
        int moveType = Random.Range(1, 3);
        if (moveType == 1)
        {
            return "Attacking";
        }
        return "Healing";
    }
}