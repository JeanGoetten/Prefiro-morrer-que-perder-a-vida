using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //movment variables
    public float speed; 
    Rigidbody2D rb; 

    SpriteRenderer spriteRenderer; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // MOVIMENTA 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0); 

        if(horizontal < 0){
            spriteRenderer.flipX = true;
        }else if(horizontal > 0){
            spriteRenderer.flipX = false;
        }
    }
}
