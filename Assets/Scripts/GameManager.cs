using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public BattleManager bm;
    public Text hpText;
    public Text manaText;

	// Use this for initialization
	void Start () {
    }

    public void RenderHand()
    {
        for (int i = 0; i < bm.player.hand.Count; i++)
        {
            Card card = bm.player.hand[i].GetComponent<Card>();
            bm.player.hand[i].transform.position = new Vector3(-4.2f + (1.9f * i), -3.3f, 0);
            card.sprite.enabled = true;
            card.box.enabled = true;
        }
    }
        // Update is called once per frame
        void Update () {
        hpText.text = "HP: " + bm.player.health.ToString() + "/" + bm.player.maxHealth.ToString();
        manaText.text = "Mana: " + bm.player.mana.ToString() + "/" + bm.player.maxMana.ToString();
        RenderHand();
    }
}
