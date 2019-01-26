using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    private inventory inventory;
    public GameObject item;
    public GameObject effect;


	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i]== false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(item, inventory.slots[i].transform, false);
                    Instantiate(effect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                }

            }
        }
    }
}
