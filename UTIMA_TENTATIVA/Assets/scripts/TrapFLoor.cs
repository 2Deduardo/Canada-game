using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFLoor : MonoBehaviour {
    public int damage;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamage player = collision.GetComponent<PlayerDamage>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

    }
}
