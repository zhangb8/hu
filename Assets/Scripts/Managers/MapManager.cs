using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapManager : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public List<GameObject> rooms;
    public GameObject currentRoom;

    public void Start()
    {
        for (int i = 0; i < roomPrefabs.Count; i++)
        {
            GameObject newRoom = Instantiate(roomPrefabs[i]) as GameObject;
            DontDestroyOnLoad(newRoom);
            rooms.Add(newRoom);
        }
        currentRoom = rooms[0];
    }

    public void InitMap(string gameState)
    {
        if (gameState == "Overworld")
        {
            foreach(GameObject room in rooms)
            {
                room.SetActive(true);
            }
        }
        if (gameState == "CardBattle")
        {
            foreach(GameObject room in rooms)
            {
                room.SetActive(false);
            }
        }
    }
}