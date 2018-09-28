using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public Card[] cards;

	// Use this for initialization
	void Start () {
        cards = new Card[5];
        FillDeck();
	}

    void FillDeck()
    {
        for (int i=0; i< cards.Length; i++)
        {
            cards[i] = Instantiate(cards[i]) as Card;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
