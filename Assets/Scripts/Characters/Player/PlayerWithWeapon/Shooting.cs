using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab; 

    public float bulletForce = 20f; 

    private void Update() {
        Shoot(); 
    }

    private void Shoot(){
        if(Input.GetMouseButtonDown(0)){
            //Shoot Animation 
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); 
        }
    }
}