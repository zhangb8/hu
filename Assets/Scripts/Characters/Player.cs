using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int block;
    public bool takenDamage = false;
    public PlayerController pc;
    public Vector2 overWorldPosition;
    public Vector2 battlePosition;
    public Vector2 overWorldScale;
    public Vector2 battleScale;

    // Use this for initialization
    void Start () {
        pc = GetComponent<PlayerController>();
        DontDestroyOnLoad(this);        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameState == "Overworld")
        {
            overWorldPosition = transform.localPosition;
        }
    }

    public void ChangeScene(string gamestate)
    {
        if (gamestate == "Overworld")
        {
            pc.enabled = true;
            transform.localPosition = overWorldPosition;
            transform.localScale = overWorldScale;
        }
        else if (gamestate == "CardBattle")
        {
            pc.enabled = false;
            transform.localPosition = battlePosition;
            transform.localScale = battleScale;
        }
    }
    public void addBlock(int blk)
    {
        block += blk;
        if (block >= 100)
        {
            block = 100;
        }
    }
    public void takeDamage(int dmg)
    {
        takenDamage = true;
        if (block > 0)
        {
            double damagePercent = Convert.ToDouble(block) / 100.0;
            double damageTaken = dmg - (damagePercent * dmg);
            dmg = Convert.ToInt32(damageTaken);
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
