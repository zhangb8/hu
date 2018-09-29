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
    public GameObject[] items;
    public GameObject deck;

    // Use this for initialization
    void Start () {
        Card.cardUsed += onCardUse;
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

    }

    void onCardUse()
    {
        //Technically knows which card was clicked on from the delegate/event
        //But there's no way to access it's information - potentially in the use
        //Function in the card class, have it send information as well
        Card.cardUsed -= onCardUse;
    }

    void startFight()
    {
        items = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < 5; i++)
        {
            GameObject slash = Instantiate(items[0]) as GameObject;
            slash.transform.parent = deck.transform;
            player.deck.Enqueue(slash);
            GameObject injection = Instantiate(items[1]) as GameObject;
            injection.transform.parent = deck.transform;
            player.deck.Enqueue(injection);
        }
        for (int i = 0; i < 5; i++)
        {
            player.Draw();
        }
    }

    void startTurn()
    {
        playerTurn = true;
        player.Draw();
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
            enemy.Heal(5);
        }
    }
}
