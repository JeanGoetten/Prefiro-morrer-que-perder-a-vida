using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //movment variables
    public float speed; 
    Rigidbody2D rb; 

    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        // MOVIMENTA 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0); 
    }
}
