﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public List<GameObject> rooms;
    public GameObject currentRoom;

	// Use this for initialization
	void Start () {
        if (GameManager.gameState == "Overworld")
        {
            for (int i=0; i<roomPrefabs.Count; i++)
            {
                GameObject room = Instantiate(roomPrefabs[i]) as GameObject;
                rooms.Add(room);
            }
        }
        currentRoom = rooms[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
