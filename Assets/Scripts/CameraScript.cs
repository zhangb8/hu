using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Vector3 offset;
    public GameObject player;

	// Use this for initialization
	void Start () {
		if (GameManager.player != null)
        {
            player = GameManager.player;
            offset = transform.position - new Vector3(0, 0, player.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
