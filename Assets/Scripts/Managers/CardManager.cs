using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Queue<GameObject> battleDeck = new Queue<GameObject>();
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discard = new List<GameObject>();
    public GameObject[] items;
    public GameObject deckObj;
    public InventoryManager im;

    public void Start()
    {

    }

    public void InitDeck()
    {
        BuildDeck();
        ShuffleDeck();
        EnqueueBattleDeck();
    }

    // takes all the items in inventory and builds deck from cards from items
    public void BuildDeck()
    {
        foreach(GameObject itemObj in im.inventory)
        {
            Item item = itemObj.GetComponent<Item>();
            foreach (GameObject co in item.cards)
            {
                GameObject cardObj = Instantiate(co) as GameObject;
                cardObj.SetActive(false);
                deck.Add(cardObj);
                cardObj.transform.parent = deckObj.transform;
            }
        }
    }

    public void EnqueueBattleDeck()
    {
        foreach (GameObject o in deck)
        {
            battleDeck.Enqueue(o);
        }
    }

    public void ShuffleDeck()
    {
        int cardCount = deck.Count;
        List<GameObject> ShuffledDeck = new List<GameObject>();
        for (int i = 0; i < cardCount; i++)
        {
            int index = Random.Range(0, deck.Count-1);
            GameObject rand = deck[index];
            deck.RemoveAt(index);
            ShuffledDeck.Add(rand);
        }
        deck = ShuffledDeck;
    }

    public void Draw()
    {
        if (battleDeck.Count > 0 && hand.Count <= 6)
        {
            hand.Add(battleDeck.Dequeue());
        }
        else if (battleDeck.Count > 0 && hand.Count == 7)
        {
            print("hand too full!");
        }
        else
        {
            print("no more cards");
        }
    }

    public void Discard(GameObject o)
    {
        discard.Add(o);
        hand.Remove(o);
        o.SetActive(false);
    }
}