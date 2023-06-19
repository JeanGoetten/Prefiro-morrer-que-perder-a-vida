using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //movment variables
    private float speed; 
    [Range(0, 1)] 
    public float backSpeedTax = 0.75f; 
    Rigidbody2D rb; 

    public static float animationSpeed; 

    public Animator characterAnimator; 
    public Transform characterSprite; 

    private StatsPlayer statsPlayer; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); 

        statsPlayer = GetComponent<StatsPlayer>(); 

        speed = statsPlayer.speed.Value; 

    }

    void Update()
    {
        // MOVIMENTA 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0); 

        // if(Mathf.Abs(rb.velocity.x) > 0){
        //     animationSpeed = Mathf.Abs(rb.velocity.x);
        // }
        // else if(Mathf.Abs(rb.velocity.y) > 0){
        //     animationSpeed = Mathf.Abs(rb.velocity.y);
        // }else{
        //     animationSpeed = 0; 
        // }

        if(characterSprite.localScale.x > 0 && horizontal > 0){
            characterAnimator.SetBool("backwalking", false); 
            characterAnimator.SetBool("walking", true); 

            speed = statsPlayer.speed.Value; 
            characterAnimator.speed = 1f; 
        }
        else if(characterSprite.localScale.x > 0 && horizontal < 0){
            characterAnimator.SetBool("walking", false); 
            characterAnimator.SetBool("backwalking", true); 

            speed = statsPlayer.speed.Value * backSpeedTax; 
            characterAnimator.speed = 1f * backSpeedTax; 
        }
        else if(characterSprite.localScale.x < 0 && horizontal > 0){
            characterAnimator.SetBool("walking", false); 
            characterAnimator.SetBool("backwalking", true); 
            
            speed = statsPlayer.speed.Value * backSpeedTax; 
            characterAnimator.speed = 1f * backSpeedTax; 
        }
        else if(characterSprite.localScale.x < 0 && horizontal < 0){
            characterAnimator.SetBool("backwalking", false); 
            characterAnimator.SetBool("walking", true); 
            
            speed = statsPlayer.speed.Value; 
            characterAnimator.speed = 1f; 
        }else{
            characterAnimator.SetBool("backwalking", false); 
            characterAnimator.SetBool("walking", false); 

            characterAnimator.speed = 1f; 

        }
        if(Mathf.Abs(rb.velocity.y) > 0){
            characterAnimator.SetBool("walking", true); 
        }
        Debug.Log(transform.localScale.x);
    }
}


