using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public List<GameObject> interactables;
    public List<GameObject> enemies;
    public void Start()
    {
        InitRoom();
    }

    public void InitRoom()
    {
        InitInteractables();
        InitEnemies();
    }

    public void InitInteractables()
    {
        foreach (GameObject i in interactables)
        {
            GameObject something = Instantiate(i, gameObject.transform) as GameObject;
        }
    }

    public void InitEnemies()
    {
        foreach (GameObject i in enemies)
        {
            GameObject something = Instantiate(i, gameObject.transform) as GameObject;

        }
    }

}