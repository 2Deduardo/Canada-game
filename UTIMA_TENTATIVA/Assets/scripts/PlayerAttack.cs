using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float timeBtwAttack;
    public float starTimeBtwAttack;

    public Transform AttackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;


	
	// Update is called once per frame
	void Update () {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position,attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                }
            }
            timeBtwAttack = starTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

       
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPos.position, attackRange);
    }
  
}
