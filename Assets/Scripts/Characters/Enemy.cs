using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {
    public int maxHealth;
    public int health;
    public int dmg;
    public int heal;
    public Vector2 overWorldPosition;
    public Vector2 battlePosition;
    public Vector2 overWorldScale;
    public Vector2 battleScale;
    public override void Interact()
    {
        print("interacting w/ enemy");
        gameObject.transform.parent = null;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        DontDestroyOnLoad(gameObject);
        GameManager.loadBattle();
    }

    private void FixedUpdate()
    {
        if (Player.ins != null)
        {
            LookAt2D (Player.ins.transform.position);
        }
    }

    public void LookAt2D(Vector2 target)
    {
        Vector2 current = transform.position;
        Vector2 direction = target - current;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 90f && angle > -90)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    public void takeDamage(int dmg)
    {
        if (health - dmg < 0)
        {
            health = 0;
        }
        else
        {
            health -= dmg;
        }
    }

    public void Heal(int heal)
    {
        if (health + heal > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += heal;
        }
    }

    public string Move()
    {
        int moveType = Random.Range(1, 3);
        if (moveType == 1)
        {
            return "Attacking";
        }
        return "Healing";
    }
}