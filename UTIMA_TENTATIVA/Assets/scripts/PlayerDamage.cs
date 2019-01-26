using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    public int healt = 5;
    public int numbOfHearts;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public bool isFull;

    private void Update()
    {
        if (healt > numbOfHearts)
        {
            healt = numbOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i< healt)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
            if (i<numbOfHearts)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled =false;
            }
        }
    }


    public void TakeDamage(int damage) {
        healt -= damage;
        if (healt<= 0 )
        {
            FindObjectOfType<GameManager>().EndGame();
            //Die();
        }

    }

    public void AddHealth(int addLife)
    {
       
        if (healt<5)
        {
            healt += addLife;
      
        }
    }

    void Die() {

        Destroy(gameObject);
    }

}
