using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //movment variables
    public float speed; 
    Rigidbody2D rb; 

    private float animationSpeed; 

    public Animator characterAnimator; 

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

        if(Mathf.Abs(rb.velocity.x) > 0){
            animationSpeed = Mathf.Abs(rb.velocity.x);
        }
        else if(Mathf.Abs(rb.velocity.y) > 0){
            animationSpeed = Mathf.Abs(rb.velocity.y);
        }else{
            animationSpeed = 0; 
        }
        //Debug.Log(animationSpeed);
        characterAnimator.SetFloat("walking", animationSpeed); 
    }
}
