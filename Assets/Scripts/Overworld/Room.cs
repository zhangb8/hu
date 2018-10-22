using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public List<GameObject> interactables;
    public List<GameObject> enemies;
    public SpriteRenderer background;
    public GameObject walls;

    public void Start()
    {
        InitRoom();
    }

    public void InitRoom()
    {
        InitInteractables();
        InitEnemies();
        InitWall();
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

    public void InitWall()
    {
        GameObject something = Instantiate(walls, gameObject.transform) as GameObject;

    }


}