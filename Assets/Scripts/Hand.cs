using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public GameObject[] cards;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Draw()
    {
        if (deck.count > 0)
        {
            hand.enqeue(deck.deqeue);
        }
        else
        {
            player.health -= 1;
        }
    }
}
