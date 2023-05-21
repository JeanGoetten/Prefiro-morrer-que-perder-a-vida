using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //MIRA
    private Transform aimTransform; 

    //DASH  
    private Rigidbody2D rb; 
    public float dashSpeed; 
    private float dashTime; 
    public float startDashTime; 
    private int direction = 0; 

    //SPRITE 
    SpriteRenderer spriteRenderer; 

    private void Awake() {
        aimTransform = transform.Find("Aim"); 

        rb = GetComponent<Rigidbody2D>(); 
        dashTime = startDashTime; 

    }
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        Aiming(); 
        Dash(); 
    }
    private void Aiming(){
        Vector3 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 aimDirection = (mousePos - transform.position).normalized; 
        float angle = MathF.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; 
        aimTransform.eulerAngles = new Vector3(0, 0, angle); 

        Debug.Log(angle);
        // flipa o srpite do personagem de acordo com o ângulo 
        if(angle < 90 && angle > -90){
            spriteRenderer.flipX = false;
        }else{
            spriteRenderer.flipX = true;
        }
    }
    public void Dash(){
        if(direction == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                direction = 1; 
            }else if(Input.GetKeyDown(KeyCode.RightArrow)){
                direction = 2; 
            }else if(Input.GetKeyDown(KeyCode.UpArrow)){
                direction = 3; 
            }else if(Input.GetKeyDown(KeyCode.DownArrow)){
                direction = 4; 
            }
        }else{
            if(dashTime <= 0){
                direction = 0; 
                dashTime = startDashTime; 
                rb.velocity = Vector2.zero; 
            }else{
                dashTime -= Time.deltaTime; 

                if(direction == 1){
                    rb.velocity = Vector2.left * dashSpeed; 
                }else if(direction == 2){
                    rb.velocity = Vector2.right * dashSpeed; 
                }else if(direction == 3){
                    rb.velocity = Vector2.up * dashSpeed; 
                }else if(direction == 4){
                    rb.velocity = Vector2.down * dashSpeed; 
                }
            }
        }




        if(Input.GetMouseButtonDown(1)){
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            rb.velocity = mousePos * dashSpeed;
        }
    }
}