﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    Enemy enemy;
    Player player;
    Sprite gameOverScreen;
    Sprite victoryScreen;
	// Use this for initialization
	void Start () {
        enemy enemy = new enemy();
        player player = new player();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.health == 0)
        {

        }

        if (player.health == 0)
        {

        }
	}

    void gameOver()
    {
        if (player.health == 0)
        {

        }
    }

    void victory()
    {
        if (enemy.health == 0)
        {

        }
    }
}
