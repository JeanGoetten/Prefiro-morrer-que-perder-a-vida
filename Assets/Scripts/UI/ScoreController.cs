using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class ScoreController : MonoBehaviour
{
     public TMP_Text scoreText;  
     public TMP_Text scoreHighText;  

     private StatsPlayer statsPlayer; 

     public float highScore = 0; 

     private void Start() {
        statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 
     }

     private void Update() {
         scoreText.text =  statsPlayer.score.Value.ToString(); 

         if(statsPlayer.score.Value > highScore){
            highScore = statsPlayer.score.Value; 
         }
         scoreHighText.text = highScore.ToString(); 
     }
}

