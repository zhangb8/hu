using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public Deck deck;
    public Hand hand;

    private void Awake()
    {

        maxHealth = 100;
        health = 100;
        maxMana = 5;
        mana = 5;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
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

    public void Heal (int heal)
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

    public void reduceMana(int x)
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

    public void addMana(int x)
    {
        mana += x;
    }

    public void Draw()
    {
        if (deck.cards.Count > 0)
        {
            hand.cards.Add(deck.cards.Dequeue());
        }
        else
        {
            takeDamage(1);
        }
    }
}
