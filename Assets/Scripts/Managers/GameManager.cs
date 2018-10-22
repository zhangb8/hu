﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameObject ins;

    //SCENE DATA
    public static string gameState;
    public static Scene currentScene;

    //MANAGERS
    public CardManager cm;
    public InventoryManager im;
    public MapManager mm;

    //OBJECTS 
    public GameObject player;
    public Camera overWorldCamera;

    //EVENTS & DELEGATES
    public delegate void ChangedScene(string gs);
    public static event ChangedScene OnChange;

    private void Awake()
    {
        if (ins == null)
        {
            ins = gameObject;
            DontDestroyOnLoad(ins);
        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        //Setting up events
        SceneManager.activeSceneChanged += GetScene;
        OnChange += mm.InitMap;

        //Initailizing fields
        currentScene = SceneManager.GetActiveScene();
        gameState = currentScene.name;
        OnChange += player.GetComponent<Player>().ChangeScene;
        OnChange(gameState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("pressed esc");
            loadMainMenu();
        }
    }

    void InitGM()
    {
        ins = gameObject;
        DontDestroyOnLoad(ins);
    }

    public void GetScene(Scene current, Scene next)
    {
        currentScene = next;
        gameState = next.name;
        OnChange(gameState);
    }

    public static void loadBattle()
    {
        SceneManager.LoadSceneAsync("CardBattle");
    }

    public static void loadOverworld()
    {
        SceneManager.LoadSceneAsync("Overworld");
    }

    public static void DeleteAll()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }

    public static void loadMainMenu()
    {
        DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
}
