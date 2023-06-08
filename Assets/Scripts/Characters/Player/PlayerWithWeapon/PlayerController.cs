using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private StatsPlayer statsPlayer; 

    private Vector3 playerStartPosition; 

    private ItemStat itemStat; 

    public GameObject aimGORight; 
    public GameObject aimGOLeft; 

    private void Start() {
        statsPlayer = GetComponent<StatsPlayer>(); 

        playerStartPosition = GetComponent<Transform>().position; 

        itemStat = GetComponent<ItemStat>(); 

        aimGORight.SetActive(false); 
        aimGOLeft.SetActive(false); 
    }
    void Update()
    {
        if(statsPlayer.life.Value <= 0){
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
        EnemiesSpawnController.bodyCount = 0; 
        SceneManager.LoadScene("Limbo");
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
}
