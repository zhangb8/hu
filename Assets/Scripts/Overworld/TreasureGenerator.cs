using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGenerator : MonoBehaviour {
    public List<GameObject> availableItems = new List<GameObject>();

	// Use this for initialization}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject RandomItem()
    {
        int treasure = Random.Range(0, availableItems.Count);
        return availableItems[treasure];
    }

}
