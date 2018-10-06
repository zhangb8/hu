using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Queue<GameObject> deck = new Queue<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discard = new List<GameObject>();
    public GameObject[] items;
    public GameObject deckObj;


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
        }
    }

    public void Discard(GameObject o)
    {
        discard.Add(o);
        hand.Remove(o);
        o.SetActive(false);
    }

    public void LoadResources()
    {
        items = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < 5; i++)
        {
            deck.Enqueue(items[0]);
            deck.Enqueue(items[1]);
        }
    }
}