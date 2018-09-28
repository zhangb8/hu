using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//leo leo on the wall who's the fairest of them all
//brian brian on my roof who's the biggest goofy goof
public class BattleManager : MonoBehaviour {

    public Enemy enemy;
    public Player player;
    public Hand hand;
    public Sprite gameOverScreen;
    public Sprite victoryScreen;

    public bool playerTurn = true;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (enemy.health == 0)
        {
            victory();
        }

        else if (player.health == 0)
        {
            gameOver();
        }
	}

    void gameOver()
    {

    }

    void victory()
    {

    }
}
