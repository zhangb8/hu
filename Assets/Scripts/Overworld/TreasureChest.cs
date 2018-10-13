using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

    public BoxCollider2D bc;
    public List<GameObject> items;

	// Use this for initialization
	void Start () {
        bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            if (Input.GetKeyDown("e"))
            {
                print("opening chest");
            }
        }
    }

    public void giveItems()
    {
        
    }
}
