using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable {
    public List<GameObject> items = new List<GameObject>();
    public int level;
    public GameObject item;
    public TreasureGenerator tg;
    public bool wasOpened = false;
    public delegate void treasureOpenedDelegate(GameObject treasure);
    public static event treasureOpenedDelegate treasureOpened;

    public void Start()
    {
        tg = GameObject.FindGameObjectWithTag("Generator").GetComponent<TreasureGenerator>();
        item = tg.RandomItem();
    }

    public override void Interact()
    {
        wasOpened = true;
        if (treasureOpened != null)
        {
            treasureOpened(item);
        }
        print("interacting with chest");
        Destroy(gameObject);
    }
}
