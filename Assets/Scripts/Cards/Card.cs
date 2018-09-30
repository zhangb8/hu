using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public int cost;
    public string type;
    public SpriteRenderer sprite;
    public BoxCollider2D box;
    public bool wasClicked = false;
    public delegate void cardUsedDelegate();
    public static event cardUsedDelegate cardUsed;
    public int val;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string getName()
    {
        return name;
    }

    void setName(string cardName)
    {
        name = cardName;
    }

    void setCost(int cardCost)
    {
        cost = cardCost;
    }

    int getCost()
    {
        return cost;
    }

    void setType(string cardType)
    {
        type = cardType;
    }

    string getType()
    {
        return type;
    }

    public void use()
    {
        wasClicked = true;
        if (cardUsed != null)
        {
            cardUsed.Invoke();
        }
    }

    private void OnMouseUpAsButton()
    {
        use();
    }
}