using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//leo leo on the wall who's the fairest of them all
//brian brian on my roof who's the biggest goofy goof
public class BattleManager : MonoBehaviour {

    public Enemy enemy;
    public Player player;
    public Hand hand;
    public Deck deck;
    public Sprite gameOverScreen;
    public Sprite victoryScreen;

    public bool playerTurn = true;

	// Use this for initialization
	void Start () {
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

    }

    void Victory()
    {

    }

    void playCard()
    {

    }

    void startFight()
    {
        for (int i = 0; i < 5; i++)
        {
            Draw();
        }
    }

    void startTurn()
    {
        playerTurn = true;
        Draw();
    }

    void endTurn()
    {
        playerTurn = false;
    }

    void enemyTurn()
    {
        string enemyMove = enemy.Move();
        if (enemyMove.equals("Attack"))
        {
            player.takeDamage(enemy.str);
        }
        else if (enemyMove.equals("Heal"))
        {
            enemy.Block();
        }
    }

    void Draw()
    {
        if (deck.length > 0)
        {
            hand.enqeue(deck[0]);
            deck.deqeue;
        }
        else
        {
            player.health -= 1;
        }
    }
}
