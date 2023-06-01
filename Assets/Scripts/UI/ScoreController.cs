using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class ScoreController : MonoBehaviour
{
     public TMP_Text scoreText;  

     private StatsPlayer statsPlayer; 

     private void Start() {
        statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 
     }

     private void Update() {
        scoreText.text =  statsPlayer.score.Value.ToString(); 
     }
}

