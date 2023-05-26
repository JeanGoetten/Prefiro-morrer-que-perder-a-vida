using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : MonoBehaviour
{
    [Range(0, 50)] public float horizontalSpeed;
    [Range(0, 50)] public float verticalSpeed; 
    public float level = 0.0f;
    //[Range(0, 1000)] public float speedRotation = 1.0f; 
    public float leftPoint, rightPoint, UPPoint, DownPoint; 
    public bool movingHorizontal = true, movingVertical = true; 

    Vector3 localScale; 
    Rigidbody2D rb; 

    private void Start() {
        localScale = transform.localScale; 

        rb = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        if(transform.position.x > rightPoint){
            movingHorizontal = false; 
        }
        if(transform.position.x < leftPoint){
            movingHorizontal = true; 
        }
        if(movingHorizontal){
            MoveRight(); 
        }
        else{
            MoveLeft(); 
        }
        
        if(transform.position.y > UPPoint)
        {
            movingVertical = false; 
        }
        if(transform.position.y < DownPoint)
        {
            movingVertical = true; 
        }
        if(movingVertical){
            MoveUP(); 
        }else{
            MoveDown(); 
        }
        //transform.eulerAngles += new Vector3(0, 0, speedRotation);
    }

    void MoveRight(){
        movingHorizontal = true; 
        localScale.x = 1; 
        transform.localScale = localScale; 
        rb.velocity = new Vector2(localScale.x * (horizontalSpeed + level), rb.velocity.y); 
    }
    void MoveLeft(){
        movingHorizontal = false; 
        localScale.x = -1; 
        transform.localScale = localScale; 
        rb.velocity = new Vector2(localScale.x * (horizontalSpeed + level), rb.velocity.y); 
    }
    void MoveUP(){
        movingVertical = true; 
        rb.velocity = new Vector2(rb.velocity.x, localScale.y * (verticalSpeed + level)); 
    }
    void MoveDown(){
        movingVertical = false; 
        rb.velocity = new Vector2(rb.velocity.x, localScale.y*(-1) * (verticalSpeed + level)); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            EnemiesSpawnController.bodyCount++; 
            EnemiesSpawnController.enemyKilled = true;  
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Enemy")
        {
            if(movingHorizontal){
                MoveLeft(); 
            }else{
                MoveRight(); 
            }
            if(movingVertical){
                MoveDown(); 
            }else{
                MoveUP(); 
            }
        }
    }
}