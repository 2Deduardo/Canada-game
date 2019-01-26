using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;
    public GameObject playerProjectille;
    public Transform shotPoint;

    private float timeBTWShots;
    public float StartTimeBTWShots;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBTWShots<= 0)
        {
           if (Input.GetMouseButtonDown(0))
             {
              Instantiate(playerProjectille, shotPoint.position, transform.rotation);
                timeBTWShots = StartTimeBTWShots;
            }
        }
        else
        {
            timeBTWShots -= Time.deltaTime;
        }


    }
}
