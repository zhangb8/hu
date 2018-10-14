using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

    public PolygonCollider2D bc;
    public List<GameObject> items;
    public bool triggered = false;
    public Collider2D contact;

	// Use this for initialization
	void Start () {
        bc = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            if (contact.gameObject.name == "Player")
            {
                if (Input.GetKeyDown("e"))
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

    public void giveItems()
    {
        
    }
}
