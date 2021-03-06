﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public float horizontalMove;
    public float verticalMove;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnDisable()
    {
        animator.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove));
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
