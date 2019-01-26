using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectle2 : MonoBehaviour {

    public float speed;

    private Transform player;
    //private Vector2 target;

    public int damage = 1;




    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {



        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == player.position.x && transform.position.y == player.position.y)
        {
            DestroyProjectile();
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        PlayerDamage player = other.GetComponent<PlayerDamage>();
        if (player != null)
        {
            player.TakeDamage(damage);
            DestroyProjectile();
        }
        else
        {
                 DestroyProjectile();
        }
       


    }
    

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
