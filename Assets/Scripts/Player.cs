using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;


	// Use this for initialization
	void Start () {
        maxHealth = 100;
        health = 100;
        maxMana = 5;
        mana = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(int dmg)
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

    void Heal (int heal)
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

    void reduceMana(int x)
    {
        if (mana - x < 0)
        {
            print("Not enough mana");
        }
        else
        {
            mana -= x;
        }
    }

    void addMana(int x)
    {
        mana += x;
    }
}
