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

    // Use this for initialization
    void Start () {
        Card.cardUsed += onCardUse;
        cm.LoadResources();
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

    void gameOver()
    {
        gameOverScreen.enabled = true;
    }

    void Victory()
    {
        victoryScreen.enabled = true;

    }

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
                break;
            }
        }
        if (cardToRemove != null)
        HandleCard(cardToRemove);
    }

    void HandleCard(GameObject o)
    {
        Card c = o.GetComponent<Card>();
        if (player.reduceMana(c.cost) == -1)
        {
            print("Not enough mana!");
            return;
        }
        if (c is Attack)
        {
            enemy.takeDamage(c.val);
        }
        else if (c is Heal)
        {
            player.Heal(c.val);
        }
        cm.Discard(o);
    }

    void startFight()
    {
        for (int i = 0; i < 5; i++)
        {
            cm.Draw();
        }
    }

    void startTurn()
    {
        playerTurn = true;
        cm.Draw();
        player.mana = player.maxMana;
    }

    public void endTurn()
    {
        playerTurn = false;
    }

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
