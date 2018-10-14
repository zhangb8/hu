using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static string gameState;
    public Scene currentScene;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
        gameState = currentScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
