using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {


    public float speed;
    private Transform target;

    //patrol
    public Transform moveSpot;
   
    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public int distance;
    //healt
    public int healt;

    //atack
    public int damage;
   

    // Use this for initialization
    void Start () {
      
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {



        if (Vector2.Distance(transform.position, target.position) > 0.50000000f && Vector2.Distance(transform.position, target.position) < distance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

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

}
