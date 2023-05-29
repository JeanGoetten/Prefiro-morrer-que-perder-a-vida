using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StatsPlayer statsPlayer; 

    private Vector3 playerStartPosition; 

    private ItemStat itemStat; 

    private void Start() {
        statsPlayer = GetComponent<StatsPlayer>(); 

        playerStartPosition = GetComponent<Transform>().position; 

        itemStat = GetComponent<ItemStat>(); 
    }
    void Update()
    {
        if(statsPlayer.life.Value <= 0){
            PlayerDied(); 
        }
    }
    public void PlayerDied(){
        Debug.Log("Player died!");

        // Player die animation 

        //
        // Restart adventure 
        //

        // Player Reposition 
        transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, 0); 
        itemStat.statsModifierLife = statsPlayer.life.BaseValue; 
        itemStat.UseItem(); 
    }
}