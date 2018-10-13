using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public new string name;
    public int cost;
    public string type;
    public SpriteRenderer sprite;
    public BoxCollider2D box;
    public bool wasClicked = false;
    public bool toBeDiscarded = false;
    public delegate void cardUsedDelegate();
    public static event cardUsedDelegate cardUsed;
    public delegate void cardDiscardedDelegate();
    public static event cardDiscardedDelegate cardDiscarded;
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

    public void discard()
    {
        toBeDiscarded = true;
        if (cardDiscarded != null)
        {
            cardDiscarded.Invoke();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            use();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            discard();
        }
    }
}