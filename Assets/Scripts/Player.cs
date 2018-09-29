using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public Queue<GameObject> deck = new Queue<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discard = new List<GameObject>();

    private void Awake()
    {

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

    public void Draw()
    {
        if (deck.Count > 0 && hand.Count <= 6)
        {
            hand.Add(deck.Dequeue());
        }

        else if (deck.Count > 0 && hand.Count == 7)
        {
            print("hand too full!");
        }
        else
        {
            print("no more cards");
            takeDamage(1);
        }
    }

    public void Discard(GameObject o)
    {
        discard.Add(o);
        hand.Remove(o);
        o.SetActive(false);
    }
}
