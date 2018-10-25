using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventory = new List<GameObject>();
    public int maxCap = 10;
    public int curWeight = 0;

    private void Start()
    {
        TreasureChest.treasureOpened += onTreasureOpened;
        getWeight();
    }

    void onTreasureOpened(GameObject treasure)
    {
        GameObject o = treasure;
        inventory.Add(o);
        print("Added a thing");
    }

    // adds up weight of all items, sets curweight to it
    public void getWeight()
    {
        for(int i=0; i<inventory.Count; i++)
        {
            GameObject o = inventory[i];
            if (o == null)
            {
                continue;
            }
            Item item = o.GetComponent<Item>();
            curWeight += item.weight;
        }
    }
}