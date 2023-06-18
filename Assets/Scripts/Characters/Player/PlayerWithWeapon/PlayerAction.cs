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
    public Transform spriteRenderer; 
    public SpriteRenderer weaponSpriteRenderer; 

    [Range(90, 135)]
    public float maxAngle = 120f; 
    [Range(45, 90)] 
    public float minAngle = 60f;  
    public bool bottomAngleLimit = true; 
    [Range(-90, -135)]
    public float maxAngleBottom = -120f; 
    [Range(-45, -90)] 
    public float minAngleBottom = -60f;  

    private void Awake() {
        aimTransform = transform.Find("Aim"); 

        rb = GetComponent<Rigidbody2D>(); 
        dashTime = startDashTime; 

    }
    private void FixedUpdate() {
        Aiming(); 
        Dash(); 
    }
    private void Aiming(){
        Vector3 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 aimDirection = (mousePos - transform.position).normalized; 
        
        float angle = MathF.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; 

        if(angle > minAngle && angle < maxAngle){
            angle = minAngle;
        }
        if(bottomAngleLimit){
            if(angle < minAngleBottom && angle > maxAngleBottom){
                angle = minAngleBottom;
            }
        }

        aimTransform.eulerAngles = new Vector3(0, 0, angle); 

        //Debug.Log(aimDirection);
        // flipa o srpite do personagem de acordo com o ângulo 
        if(angle < 90 && angle > -90){
            spriteRenderer.localScale = new Vector3(1, 1, 1); 
        }else{
            spriteRenderer.localScale = new Vector3(-1, 1, 1); 
        }
        // flipa o sprite da arma de acordo com o ângulo
        if(angle < 90 && angle > -90){
            weaponSpriteRenderer.flipY = false;
        }else{
            weaponSpriteRenderer.flipY = true;
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
