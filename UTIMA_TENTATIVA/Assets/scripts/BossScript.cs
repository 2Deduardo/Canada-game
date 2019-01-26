using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour {

    public float speed;
    private Transform target;

    public GameObject[] enemies;
    public int instDistance;
    public int enemyType;
    public Transform[] instpos;

    private float timeBTWSpawn;
    public float StartTimeBTWSpawn;
    public Slider healthBar;
    public float health;
    public GameObject effect;
    public GameObject finalTalk;


    public int distance;
    
    //atack
    public int damage;


    // Use this for initialization
    void Start()
    {
        timeBTWSpawn = StartTimeBTWSpawn;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        enemyType = Random.Range(0, enemies.Length);
        healthBar.value = health; 



        if (Vector2.Distance(transform.position, target.position) > 0.50000000f && Vector2.Distance(transform.position, target.position) < distance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position)< instDistance && Vector2.Distance(transform.position,target.position)>distance)
        {
            if (timeBTWSpawn<=0)
            {
                for (int i = 0; i < instpos.Length; i++)
                    {
                     Instantiate(enemies[enemyType], instpos[i].position, Quaternion.identity);

                    }
                    timeBTWSpawn = StartTimeBTWSpawn;
            }
            else
            {
                timeBTWSpawn -= Time.deltaTime;
            }
           

        }
        if (health<=15)
        {
            speed =6f;
        }
       


       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamage player = collision.GetComponent<PlayerDamage>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

    }

    

    public void TakeDamage(float damage)
    {

        health -= damage;
        Debug.Log("damage TAKEN");
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(finalTalk, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
