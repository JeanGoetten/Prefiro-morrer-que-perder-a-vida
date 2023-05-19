using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIssacStyleController : MonoBehaviour
{
    //movment variables
    public float speed; 
    Rigidbody2D rb; 

    private float lastPlayerMoveX = 1f; 
    private float lastPlayerMoveY = 0f; 

    //shoot variables
    public GameObject bulletPrefab; 
    public float bulletSpeed; 
    private float lastFire; 
    public float fireRate; 

    //controle
    public bool hitInMouseDirection = false; 



    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        // MOVIMENTA 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        //Debug.Log(horizontal);
        //Debug.Log(vertical);

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0); 

        // registra a direção da última movimentação do player
        if(horizontal != 0 || vertical != 0){
            lastPlayerMoveX = horizontal; 
            lastPlayerMoveY = vertical; 
        }

        // ATIRA
        //atira com as setas do teclado nas 4 direções 
        float shootHorizontal = Input.GetAxis("ShootHorizontal");
        float shootVertical = Input.GetAxis("ShootVertical");

        if((shootHorizontal != 0 || shootVertical != 0) && Time.time > lastFire + fireRate)
        {
            Shoot(shootHorizontal, shootVertical);
            lastFire = Time.time;
        }
        // controla a opção do inspetor para atirar com o mouse 
        if(hitInMouseDirection){
            //atira com o click do mouse na direção do cursor do mouse  
            if (Input.GetMouseButtonDown(0) && Time.time > lastFire + fireRate){
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;
                Shoot(x, y); 
                lastFire = Time.time;
            }
        }else{
            //atira com o click do mouse nas 8 direções do personagem 
            if (Input.GetMouseButtonDown(0) && Time.time > lastFire + fireRate){
                Shoot(lastPlayerMoveX, lastPlayerMoveY);
                lastFire = Time.time;
            }
        }
    }

    void Shoot(float x, float y){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject; 
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0; 
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, 
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed, 
            0
        ); 
    }
}
