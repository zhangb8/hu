using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    string name;
    int cost;
    string type;

	// Use this for initialization
	void Start () {
        name = "";
        cost = "";
        type = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setName(string cardName)
    {
        name = cardName;
    }

    void setCost(int cardCost)
    {
        cost = cardCost;
    }

    void setType(string cardType)
    {
        type = cardType;
    }
}
