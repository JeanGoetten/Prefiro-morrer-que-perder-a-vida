using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : MonoBehaviour
{
    [Range(0, 50)] public float horizontalSpeed;
    [Range(0, 50)] public float verticalSpeed; 
    [Range(0, 50)] public float followSpeed; 
    //[Range(0, 1000)] public float speedRotation = 1.0f; 
    public float leftPoint, rightPoint, UPPoint, DownPoint; 
    private bool movingHorizontal = true, movingVertical = true; 

    public float level = 0.0f;
    public float timeToRespawn = 0.0f;
    public float timeAfterFXSummon = 0.0f;

    Vector3 localScale; 
    Rigidbody2D rb; 

    private ItemStat itemStat; 

    private bool canDamage; 
    public float damageCooldownTime; 

    new public AudioSource audio; 
    public AudioClip SFX_playerHurt; 
    public AudioClip SFX_atack; 
    public AudioClip SFX_chase; 

    public GameObject FX_toDie; 
    public GameObject FX_impact; 

    Animator anim; 
    public float spawnAnimationTime = 0.1f; 
    private float spawnAnimationTimeControll; 

    private bool spawned; 

    private void Start() {
        localScale = transform.localScale; 

        rb = GetComponent<Rigidbody2D>(); 

        itemStat = GetComponent<ItemStat>(); 

        canDamage = true; 

        anim = GetComponent<Animator>(); 

        spawned = false; 

        spawnAnimationTimeControll = 0f; 

    }
    private void FixedUpdate(){
        spawnAnimationTimeControll += Time.deltaTime; 
        
    }
    void Update()
    {
        if(spawnAnimationTimeControll >= spawnAnimationTime){
            spawned = true; 
        }
        if(spawned){
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
            //Debug.Log("Enemy bulleted!");
            EnemiesSpawnController.bodyCount++; 
            EnemiesSpawnController.enemyKilled = true;  
            itemStat.DropItem(); 


            Instantiate(FX_impact, transform.position, transform.rotation); 
            Instantiate(FX_toDie, transform.position, transform.rotation); 
            
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
        if(other.gameObject.tag == "Player"){
            //Debug.Log("Player hurted!");
            anim.SetTrigger("atack"); 
            audio.PlayOneShot(SFX_playerHurt); 
            itemStat.UseItem(); 
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            //Debug.Log("Player hurted!");
            if(canDamage){
                anim.SetTrigger("atack"); 
                audio.PlayOneShot(SFX_playerHurt); 
                itemStat.UseItem(); 
                StartCoroutine(InvulnerableTime()); 
            }
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            if(spawned){
                Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, transform.position.z);
                Vector3 velocity = (targetPos - transform.position) * followSpeed;
                transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);

                if(other.gameObject.transform.position.x <= transform.position.x + 2f){
                    MoveLeft(); 
                    //Debug.Log("player à esquerda");
                }else if(other.gameObject.transform.position.x > transform.position.x - 2f){
                    MoveRight(); 
                    //Debug.Log("player à direita");
                }else{
                    //MoveRight(); 
                }
            }
        }else{
            // berro 
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(SFX_chase); 
        }
    }
    IEnumerator InvulnerableTime(){
        canDamage = false; 
        yield return new WaitForSeconds(damageCooldownTime); 
        canDamage = true; 
    }
}