using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//leo leo on the wall who's the fairest of them all
//brian brian on my roof who's the biggest goofy goof
public class BattleManager : MonoBehaviour {

    public Enemy enemy;
    public Player player;
    public Image gameOverScreen;
    public Image victoryScreen;
    public bool playerTurn = true;
    public CardManager cm;
    public InventoryManager im;

    // Use this for initialization
    void Start () {
        Card.cardUsed += onCardUse;
        cm.InitDeck();
        startFight();
    }

	// Update is called once per frame
	void Update () {
		if (enemy.health == 0)
        {
            Victory();
        }

        else if (player.health == 0)
        {
            gameOver();
        }

        if (playerTurn == false)
        {
            enemyTurn();
            startTurn();
        }
	}

    //displays game over screen
    void gameOver()
    {
        gameOverScreen.enabled = true;
    }

    //displays victory screen
    void Victory()
    {
        victoryScreen.enabled = true;

    }

    //this is called when a card is clicked and the event is called
    //iterates through cards in hand to find the one that was clicked
    //then handles the card
    void onCardUse()
    {
        GameObject cardToRemove = null;
        print("card used");
        foreach (GameObject o in cm.hand)
        {
            Card c = o.GetComponent<Card>();
            if (c.wasClicked)
            {
                cardToRemove = o;
                c.wasClicked = false;
                break;
            }
        }
        if (cardToRemove != null)
        HandleCard(cardToRemove);
    }

    //handles what a card does
    //needs to be reworked so that abilities aren't hardcoded in
    void HandleCard(GameObject o)
    {
        Card c = o.GetComponent<Card>();
        //checks if player has enough mana
        if (player.reduceMana(c.cost) == -1)
        {
            print("Not enough mana!");
            return;
        }
        //this part needs to be reworked
        //hardcodes how cards are used
        if (c is Attack)
        {
            enemy.takeDamage(c.val);
        }
        else if (c is Heal)
        {
            player.Heal(c.val);
        }
        else if (c is Defense)
        {
            player.addBlock(c.val);
        }
        cm.Discard(o);
    }

    //draws 5 cards
    void startFight()
    {
        for (int i = 0; i < 5; i++)
        {
            cm.Draw();
        }
    }

    //called when it is player's turn
    //draws a card and resets mana
    void startTurn()
    {
        playerTurn = true;
        cm.Draw();
        player.mana = player.maxMana;
    }

    //changes to enemy's turn
    public void endTurn()
    {
        playerTurn = false;
    }

    //enemy turn logic
    void enemyTurn()
    {
        string enemyMove = enemy.Move();
        if (enemyMove.Equals("Attack"))
        {
            player.takeDamage(enemy.str);
        }
        else if (enemyMove.Equals("Heal"))
        {
            enemy.Heal(enemy.def);
        }
    }
}
