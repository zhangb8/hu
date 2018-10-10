﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int block;
    public bool takenDamage = false;


    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addBlock(int blk)
    {
        block += blk;
    }

    public void takeDamage(int dmg)
    {
        takenDamage = true;
        //if (damageTake != null)
        //{
        //    damageTake.Invoke();
        //}
        if ((block - dmg) >= 0)
        {
            block -= dmg;
        }
        else if ((block-dmg) < 0)
        {
            dmg = dmg - block;
            block = 0;
            if (health - dmg < 0)
            {
                health = 0;
            }
            else
            {
                health -= dmg;
            }
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

    public int reduceMana(int x)
    {
        if (mana - x < 0)
        {
            print("Not enough mana");
            return -1;
        }
        else
        {
            mana -= x;
            return x;
        }
    }
    public void addMana(int x)
    {
        mana += x;
    }




}
