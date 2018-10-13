using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    public BattleManager bm;
    public CardManager cm;
    public Text hpText;
    public Text manaText;
    public Text enemyHpText;
    public Text deckText;
    public Text intentionText;

    void Start () {
    }

    //renders everything every frame (pretty bad for runtime)
    void Update()
    {
        Render();
    }

    //Renders everything at once
    public void Render()
    {
        RenderHP();
        RenderMana();
        RenderHand();
        RenderDeck();
    }

    // Makes whatever's in ur hand (cm.hand) show up on the screen in the right place
    public void RenderHand()
    {
        for (int i = 0; i < cm.hand.Count; i++)
        {
            GameObject cardObj = cm.hand[i];
            cardObj.SetActive(true);
            cardObj.transform.position = new Vector3(390 + (230 * i), 190, 0);
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

    public void RenderDeck()
    {
        deckText.text = "Cards Left: " + cm.battleDeck.Count.ToString();
    }

}
