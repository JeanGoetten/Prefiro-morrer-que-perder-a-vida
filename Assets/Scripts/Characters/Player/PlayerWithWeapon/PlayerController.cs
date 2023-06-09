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

    private bool playerAlive; 

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
        audio.clip = SFX_playerDie; 
        audio.Play(); 
        txtBodyCount.text = EnemiesSpawnController.bodyCount.ToString();
        endMenuPanel.SetActive(true);
        Time.timeScale = 0f;

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
        SceneManager.LoadScene("Limbo");
    }
}
