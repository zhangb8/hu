using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public new string name;
    public int cost;
    public string type;
    public bool wasClicked = false;
    public bool toBeDiscarded = false;
    public delegate void cardUsedDelegate();
    public static event cardUsedDelegate cardUsed;
    public delegate void cardDiscardedDelegate();
    public static event cardDiscardedDelegate cardDiscarded;
    public Text manaText;
    public Text titleText;
    public Text descriptionText;
    public Text typeText;
    public int val;
    // Use this for initialization
    void Start () {
        RenderCard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RenderCard()
    {
        titleText.text = name;
        manaText.text = cost.ToString();
        descriptionText.text = getDescription();
        typeText.text = type;
    }

    public string getDescription()
    {
        string result = "";
        string valStr = val.ToString();
        switch (type)
        {
            case "Attack":
                result = "Deal " + valStr + " damage.";
                break;
            case "Heal":
                result = "Heal " + valStr + " health.";
                break;
            case "Defense":
                result = "Reduce damage by " + valStr + "%.";
                break;
            default:
                result = "No description";
                break;
        }
        return result;
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