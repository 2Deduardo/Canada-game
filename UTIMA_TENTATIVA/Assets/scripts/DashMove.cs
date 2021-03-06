﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour {
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public GameObject dashEffect;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction ==0 )
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                direction = 3;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                direction = 4;
            }
            else
            {
                if (dashTime<=0 )
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction ==1 && Input.GetKeyDown(KeyCode.Space))
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }else if (direction == 2 && Input.GetKeyDown(KeyCode.Space))
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }else if (direction == 3 && Input.GetKeyDown(KeyCode.Space))
                    {
                        rb.velocity = Vector2.up * dashSpeed;
                    }else if (direction == 4 && Input.GetKeyDown(KeyCode.Space))
                    {
                        rb.velocity = Vector2.down * dashSpeed;
                    }
                }
            }
      
        }
	}
}
