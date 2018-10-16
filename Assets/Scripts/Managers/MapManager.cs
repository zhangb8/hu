using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public List<GameObject> roomPrefabs;
    public List<GameObject> rooms;
    public GameObject currentRoom;
    private void Awake()
    {
        GameManager.OnChange += InitMap;
    }

    void InitMap(string gameState)
    {
        print("calling initmap");
        if (gameState == "Overworld")
        {
            for (int i = 0; i < roomPrefabs.Count; i++)
            {
                GameObject room = Instantiate(roomPrefabs[i]) as GameObject;
                rooms.Add(room);
            }
            currentRoom = rooms[0];
        }
    }
}
