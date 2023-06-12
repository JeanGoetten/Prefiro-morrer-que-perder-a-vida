using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static bool canShoot; 

    public Transform firePoint; 
    private GameObject bulletPrefab; 
    public GameObject FX_shoot; 
    public new Transform camera; 

    private float bulletForce; 

    private float fireTime; 

    private bool freeFire = true; 

    new public AudioSource audio; 

    public MimicSpawn mimicSpawn; 

    private void Start() {
        canShoot = false; 
        fireTime = 0; 

    }

    private void Update() {
        bulletPrefab = WeaponController.bullet; 
        bulletForce = WeaponController.force; 

        freeFire = MimicSpawn.freeFire; 

        fireTime += Time.deltaTime; 
        //Debug.Log(fireTime);

        if(fireTime > 1/WeaponController.fireRate){
            Shoot(); 
        }else{
            // cant shoot
        }
    }

    private void Shoot(){
        if(freeFire){
            if(Input.GetMouseButton(0)){
            //Shoot Animation 
            
            // verify and instatiate 
                if(!PauseGame.gameIsPaused && canShoot){
                    camera.GetComponent<ScreenShake>().start = true; 
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
                    Instantiate(FX_shoot, firePoint.position, firePoint.rotation); 
                    //bullet.transform.parent = firePoint.transform; 
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
                    rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); 
                    fireTime = 0; 
                    audio.PlayOneShot(mimicSpawn.SFX_Shot);
                }
            }   
        }else{
            if(Input.GetMouseButtonDown(0)){
            //Shoot Animation 
            
            // verify and instatiate 
                if(!PauseGame.gameIsPaused && canShoot){
                    camera.GetComponent<ScreenShake>().start = true; 
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
                    Instantiate(FX_shoot, firePoint.position, firePoint.rotation); 
                    //bullet.transform.parent = firePoint.transform; 
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
                    rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); 
                    fireTime = 0; 
                    audio.PlayOneShot(mimicSpawn.SFX_Shot);
                }
            }
        }
        
    }
}
