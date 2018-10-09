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
        deck = ShuffleDeck(deck);
        EnqueueBattleDeck(deck);
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

    //enqueues everything in deck to battledeck
    public void EnqueueBattleDeck(List<GameObject> d)
    {
        foreach (GameObject o in d)
        {
            battleDeck.Enqueue(o);
        }
    }

    //shuffles everything in deck
    public List<GameObject> ShuffleDeck(List<GameObject> d)
    {
        int cardCount = d.Count;
        List<GameObject> ShuffledDeck = new List<GameObject>();
        for (int i = 0; i < cardCount; i++)
        {
            int index = Random.Range(0, d.Count-1);
            GameObject rand = d[index];
            d.RemoveAt(index);
            ShuffledDeck.Add(rand);
        }
        return ShuffledDeck;
    }

    //puts a card from battledeck to hand
    public void Draw()
    {
        if (hand.Count == 7)
        {
            print("hand too full!");
        }
        else
        {
            if (battleDeck.Count == 0)
            {
                DiscardToDeck();
            }
            hand.Add(battleDeck.Dequeue());
        }
    }

    //discards hand to discard pile
    public void Discard(GameObject o)
    {
        discard.Add(o);
        hand.Remove(o);
        o.SetActive(false);
    }

    public void DiscardToDeck()
    {
        print("no more cards");
        discard = ShuffleDeck(discard);
        EnqueueBattleDeck(discard);
        discard.Clear();
    }
}