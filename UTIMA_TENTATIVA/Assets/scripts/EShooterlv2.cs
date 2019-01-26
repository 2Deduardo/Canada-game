using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShooterlv2 : MonoBehaviour {
    public float speed;
    private Transform target;
    private Transform enemyTarget;

    //patrol
    public Transform moveSpot;

    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public int distance;

    //shooting
    private float timeBTWShots;
    public float StartTimeBTWShots;

    public GameObject projectile;
    public Transform[] shotPos;



    // Use this for initialization
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //enemyTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();

        timeBTWShots = StartTimeBTWShots;
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position, target.position) > 3 && Vector2.Distance(transform.position, target.position) < distance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            waitTime = startWaitTime;

        }
        else if (Vector2.Distance(transform.position, target.position) < 3)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
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


        if (timeBTWShots <= 0 && Vector2.Distance(transform.position, target.position) < 10)
        {
            for (int i = 0; i < shotPos.Length; i++)
            {
            Instantiate(projectile, shotPos[i].position, Quaternion.identity);
            }
            
            timeBTWShots = StartTimeBTWShots;
        }
        else
        {
            timeBTWShots -= Time.deltaTime;
        }
    }

}
