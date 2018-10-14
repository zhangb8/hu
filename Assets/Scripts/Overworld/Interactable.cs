using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public PolygonCollider2D bc;
    public bool triggered = false;
    public Collider2D contact;

    void Start()
    {
        getCollider();
    }

    void getCollider()
    {
        bc = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == "Overworld")
        {
            if (triggered)
            {
                if (contact.gameObject.name == "Player" && Input.GetKeyDown("e"))
                {
                    print("opening chest");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        contact = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
        contact = null;
    }
}
