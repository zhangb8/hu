using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapManager : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public List<GameObject> rooms;
    public GameObject currentRoom;
    public GameObject roomParent;

    public void Start()
    {
        roomParent = new GameObject("Rooms");
        DontDestroyOnLoad(roomParent);
        for (int i = 0; i < roomPrefabs.Count; i++)
        {
            GameObject newRoom = Instantiate(roomPrefabs[i], position: new Vector3(i * 17.75f, 0, 0), rotation: new Quaternion(0, 0, 0, 0), parent: roomParent.transform) as GameObject;
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