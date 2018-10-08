using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public BattleManager bm;
    public CardManager cm;
    public Text hpText;
    public Text manaText;
    public Text enemyHpText;

	void Start () {
        Player.damageTake += Render;
    }

    //renders everything every frame (pretty bad for runtime)
    void Update()
    {

    }

    //Renders everything at once
    public void Render()
    {
        RenderHP();
        RenderMana();
        RenderHand();
    }

    // Makes whatever's in ur hand (cm.hand) show up on the screen in the right place
    public void RenderHand()
    {
        for (int i = 0; i < cm.hand.Count; i++)
        {
            GameObject cardObj = cm.hand[i];
            Card card = cardObj.GetComponent<Card>();
            cardObj.SetActive(true);
            cardObj.transform.position = new Vector3(-4.2f + (1.9f * i), -3.3f, 0);
            card.sprite.enabled = true;
            card.box.enabled = true;
        }
    }

    // Makes the health text correct every frame
    public void RenderHP()
    {
        hpText.text = "HP: " + bm.player.health.ToString() + "/" + bm.player.maxHealth.ToString();
        enemyHpText.text = "HP: " + bm.enemy.health.ToString() + "/" + bm.enemy.maxHealth.ToString();
    }

    // Makes the mana text correct every frame
    public void RenderMana()
    {
        manaText.text = "Mana: " + bm.player.mana.ToString() + "/" + bm.player.maxMana.ToString();
    }



}
