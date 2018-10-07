using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventory = new List<GameObject>();
    public int maxCap = 10;
    public int curWeight = 0;

    private void Start()
    {
        getWeight();
    }

    // adds up weight of all items, sets curweight to it
    public void getWeight()
    {
        foreach (GameObject o in inventory)
        {

            Item item = o.GetComponent<Item>();
            curWeight += item.weight;
        }
    }
}