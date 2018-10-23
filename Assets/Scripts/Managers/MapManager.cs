using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapManager : MonoBehaviour {

    public MultiArray[] roomPrefabs;
    public List<GameObject> rooms;
    public GameObject currentRoom;
    public GameObject roomParent;

    public void Start()
    {
        roomParent = new GameObject("Rooms");
        DontDestroyOnLoad(roomParent);
        for (int i = 0; i < roomPrefabs.Length; i++)
        {
            for (int j = 0; j< roomPrefabs[i].Count(); j++)
            {
                GameObject newRoom = Instantiate(roomPrefabs[i].array[j], position: new Vector3(17.6f*j, (9.8f*(roomPrefabs.Length-1 - i)), 0), rotation: new Quaternion(0, 0, 0, 0), parent: roomParent.transform) as GameObject;
                rooms.Add(newRoom);
            }
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