﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;

    public int damage = 1;
    
    
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        
	}
	
	// Update is called once per frame
	void Update () {

       
            
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            PlayerDamage player = collision.GetComponent<PlayerDamage>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            DestroyProjectile();
            
        
    }

    void DestroyProjectile() {
        
        Destroy(gameObject);
    }
}  
