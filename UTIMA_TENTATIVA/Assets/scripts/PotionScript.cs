using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{

    public int addLife = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamage player = collision.GetComponent<PlayerDamage>();
        if (player != null)
        {
            if (player.healt<5)
            {
                player.AddHealth(addLife);
                Destroy(gameObject);
            }
            
        }

    }
}

  
