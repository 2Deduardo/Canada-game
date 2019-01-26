using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float health;
    public GameObject effect;

    

    void Update()
    {
 
        if (health<=0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(float damage) {

        health -= damage;
        Debug.Log("damage TAKEN");
    }
}
