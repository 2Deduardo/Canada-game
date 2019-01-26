using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

   
    private Transform target;

  

    //shooting
    private float timeBTWSpawn;
    public float StartTimeBTWSpawn;
    public int enemyType;
    public GameObject [] enemy;

    public int distance;


    public int wave;



    // Use this for initialization
    void Start()
    {
       
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        timeBTWSpawn = StartTimeBTWSpawn;
    }

    // Update is called once per frame
    void Update()
    {   enemyType = Random.Range(0, enemy.Length);


        if (timeBTWSpawn <= 0 && Vector2.Distance(transform.position, target.position) < distance)
        {
            if (wave > 0)
            {
                Instantiate(enemy[enemyType], transform.position, Quaternion.identity);
                timeBTWSpawn = StartTimeBTWSpawn;
                wave -= 1;
            }

        }
        else
        {
            timeBTWSpawn -= Time.deltaTime;
        }
    }


}
