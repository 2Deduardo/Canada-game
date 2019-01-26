using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float damage ;


    public GameObject effect;
   

   
    private void Start()
    {
        
        rb.velocity = transform.right * speed;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossScript boss = collision.GetComponent<BossScript>();
        EnemyDamage enemy = collision.GetComponent<EnemyDamage>();
        if (enemy != null)
        {
            
            enemy.TakeDamage(damage);
        }
        else if (boss != null)
        {
            boss.TakeDamage(damage);
        }

        Instantiate(effect, transform.position, Quaternion.identity);
        
        
        Destroy(gameObject);
    }




}

	// Use this for initialization
	
