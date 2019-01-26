using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 movevelocity;


    //dash
    public float dashSpeed;
    private float dashTime;
    public float startdashTime;


    public GameObject effect;

   
    

    void Start()
    {
        rb = GetComponent < Rigidbody2D >();
        dashTime = startdashTime;
    }


    // Update is called once per frame
    void Update () {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movevelocity = moveInput.normalized * speed;

       
       

        //dash
        if (dashTime <= 0)
        {
            dashTime = startdashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                 
                Vector2 startDash = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                Instantiate(effect, transform.position, Quaternion.identity);
                movevelocity = startDash.normalized * dashSpeed;
               
                
            }
        }
    }

    private void FixedUpdate()
    {   //movement
        rb.MovePosition(rb.position + movevelocity * Time.fixedDeltaTime);
    }

    

}
