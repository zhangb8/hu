using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int maxHealth;
    public int health;
    public int str;
    public int def;
    public int block;

	// Use this for initialization
	void Start () {
        maxHealth = 50;
        health = 50;
        str = 10;
        def = 10;
        block = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(int dmg)
    {
        if (block > 0)
        {
            dmg -= block;
        }

        if (health - dmg < 0)
        {
            health = 0;
        }
        else
        {
            health -= dmg;
        }
    }

    void Heal(int heal)
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

    void Block()
    {
        block += def;
    }

    String Move()
    {
        Random rnd = new Random();
        int moveType = rnd.Next(1, 2);
        if (moveType == 1)
        {
            return "Attack";
        }
        else
        {
            return "Heal";
        }
    }
}
