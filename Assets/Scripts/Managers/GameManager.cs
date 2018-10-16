using System.Collections;
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
    public BattleManager bm;
    public MapManager mm;

    //OBJECTS 
    public GameObject playerPrefab;
    public GameObject player;

    //EVENTS & DELEGATES
    public delegate void ChangedScene(string gs);
    public static event ChangedScene OnChange;

	// Use this for initialization
	void Start () {
        if (ins == null)
        {
            ins = gameObject;
            DontDestroyOnLoad(ins);
        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }
        SceneManager.activeSceneChanged += GetScene;
        currentScene = SceneManager.GetActiveScene();
        gameState = currentScene.name;
        InstantiatePlayer();
        bm.player = player.GetComponent<Player>();
        OnChange(gameState);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitGM()
    {
        ins = gameObject;
        DontDestroyOnLoad(ins);
    }

    void InstantiatePlayer()
    {
        player = Instantiate(playerPrefab) as GameObject;
    }

    public void GetScene(Scene current, Scene next)
    {
        currentScene = next;
        gameState = next.name;
        print("calling onchange from gm");
        print("gamestate = " + gameState);
        OnChange(gameState);
    }

    public static void loadBattle()
    {
        SceneManager.LoadScene("CardBattle");

    }
}
