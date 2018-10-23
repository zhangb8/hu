using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public List<GameObject> interactables;
    public List<GameObject> enemies;
    public List<Vector3> interactablePositions;
    public List<Vector3> enemyPositions;
    public SpriteRenderer sr;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        InitRoom();
        //DisableAll();
    }

    public void DisableAll()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
        sr.enabled = false;
    }

    public void EnableAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        }
        sr.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //EnableAll();
        }
    }


    public void InitRoom()
    {
        InitInteractables();
        InitEnemies();
    }

    public void InitInteractables()
    {
        for (int i=0; i<interactables.Count; i++)
        {
            GameObject something = Instantiate(interactables[i], interactablePositions[i]+gameObject.transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform) as GameObject;
        }
    }

    public void InitEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            GameObject something = Instantiate(enemies[i], enemyPositions[i]+gameObject.transform.position, new Quaternion(0, 180, 0, 0), gameObject.transform) as GameObject;
        }
    }
}