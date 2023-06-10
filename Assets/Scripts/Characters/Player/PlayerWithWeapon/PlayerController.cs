using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    private StatsPlayer statsPlayer; 

    private Vector3 playerStartPosition; 

    private ItemStat itemStat; 

    public GameObject aimGORight; 
    public GameObject aimGOLeft; 

    public GameObject endMenuPanel; 

    public TMP_Text txtBodyCount; 

    new public AudioSource audio; 
    public AudioClip SFX_playerDie; 
    public AudioClip sfx_btnClick; 

    private bool playerAlive; 

    public Animator anim; 

    public Collider2D playerCollider; 

    private void Start() {
        statsPlayer = GetComponent<StatsPlayer>(); 

        playerStartPosition = GetComponent<Transform>().position; 

        itemStat = GetComponent<ItemStat>(); 

        aimGORight.SetActive(false); 
        aimGOLeft.SetActive(false); 

        endMenuPanel.SetActive(false);

        playerAlive = true; 

        //EnemiesSpawnController.bodyCount = 0; 
    }
    void Update()
    {
        if(statsPlayer.life.Value <= 0 && playerAlive){
            PlayerDied(); 
        }
        if(Shooting.canShoot){
            aimGORight.SetActive(true); 
            aimGOLeft.SetActive(true); 
        }else{
            aimGORight.SetActive(false); 
            aimGOLeft.SetActive(false); 
        }
    }
    public void PlayerDied(){
        playerAlive = false; 
        audio.Stop(); 
        audio.PlayOneShot(SFX_playerDie); 
        txtBodyCount.text = EnemiesSpawnController.bodyCount.ToString();
        endMenuPanel.SetActive(true);
        // Time.timeScale = 0f;
        playerCollider.enabled = false; 
        Shooting.canShoot = false; 
        

        //Debug.Log("Player died!");

        // Player die animation 

        //
        // Restart adventure 
        //

        // Score Register 

        // Player Reposition 
        // transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, 0); 
        // itemStat.statsModifierLife = statsPlayer.life.BaseValue; 
        // itemStat.statsModifierScore = statsPlayer.score.Value * -1;
        // itemStat.UseItem(); 

        // // Item reroll
        // GameObject.FindGameObjectWithTag("Mimic").GetComponent<MimicSpawn>().itemSpawnAvaiable = true; 
    }
    public void Restart(){
        audio.Stop(); 
        audio.PlayOneShot(sfx_btnClick); 
        anim.SetTrigger("fadeIn"); 
        StartCoroutine(cd()); 
    }
    IEnumerator cd(){
        yield return new WaitForSeconds(2); 
        SceneManager.LoadScene("Limbo");
    }
}
