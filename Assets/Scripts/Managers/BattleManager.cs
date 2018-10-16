using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//leo leo on the wall who's the fairest of them all
//brian brian on my roof who's the biggest goofy goof
public class BattleManager : MonoBehaviour {

    public Enemy enemy;
    public Player player;
    public bool playerTurn = true;
    public CardManager cm;
    public InventoryManager im;
    public string enemyMove;

    // Use this for initialization
    void Start () {
        GameManager.OnChange += StartBattle;
        Card.cardUsed += onCardUse;
        Card.cardDiscarded += onCardDiscard;
    }

    void StartBattle(string gameState)
    {
        if (gameState == "CardBattle")
        {
            enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
            enemy.gameObject.transform.localPosition = enemy.battlePosition;
            enemy.gameObject.transform.localScale = enemy.battleScale;
            cm.deckObj = GameObject.FindGameObjectWithTag("deck");
            cm.InitDeck();
            startTurn();
        }
    }

	// Update is called once per frame
	void Update () {
        if (GameManager.gameState == "CardBattle")
        {
            if (playerTurn == false)
            {
                enemyTurn();
                startTurn();
            }
        }
    }

    //this is called when a card is clicked and the event is called
    //iterates through cards in hand to find the one that was clicked
    //then handles the card
    void onCardUse()
    {
        print("used card");
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

    void onCardDiscard()
    {
        GameObject cardToRemove = null;
        print("card discarded");
        foreach (GameObject o in cm.hand)
        {
            Card c = o.GetComponent<Card>();
            if (c.toBeDiscarded)
            {
                cardToRemove = o;
                c.toBeDiscarded = false;
                break;
            }
        }
        if (cardToRemove != null)
            discardCard(cardToRemove);
    }

    void discardCard(GameObject o)
    {
        cm.Discard(o);
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
        switch (c.type)
        {
            case "Attack":
                enemy.takeDamage(c.val);
                break;
            case "Heal":
                player.Heal(c.val);
                break;
            case "Defense":
                player.addBlock(c.val);
                break;
            default:
                print("no type found");
                break;
        }
        cm.Discard(o);
    }

    public void reshuffle()
    {
        if (player.reduceMana(3) != -1)
        {
            cm.DiscardToDeck();
        }
    }

    //called when it is player's turn
    //draws a card, resets mana and block
    void startTurn()
    {
        playerTurn = true;
        player.block = 0;
        while (cm.battleDeck.Count != 0 && cm.hand.Count < 4)
        {
            cm.Draw();
        }
        if (cm.battleDeck.Count != 0)
        {
            cm.Draw();
        }
        player.mana = player.maxMana;
        enemyMove = enemy.Move();
    }

    //changes to enemy's turn
    public void endTurn()
    {
        playerTurn = false;
    }

    //enemy turn logic
    void enemyTurn()
    {
        if (enemyMove.Equals("Attacking"))
        {
            player.takeDamage(enemy.dmg);
        }
        else if (enemyMove.Equals("Healing"))
        {
            enemy.Heal(enemy.heal);
        }
    }
}
