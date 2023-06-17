using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class ScoreController : MonoBehaviour
{
   public TMP_Text scoreText;  
   public TMP_Text scoreHighText;  

   private StatsPlayer statsPlayer; 

   public static float highScore = 0; 

   Animator anim; 

   private void Start() {
      statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 
      anim = GetComponent<Animator>(); 
   }

   private void Update() {
      if(highScore <= 0){
         scoreHighText.enabled = false; 
      }else{
         scoreHighText.enabled = true; 
      }
       
      scoreText.text =  statsPlayer.score.Value.ToString(); 

      if(statsPlayer.score.Value > highScore){
         scoreHighText.color = Color.yellow; 
         anim.SetTrigger("popup"); 
         highScore = statsPlayer.score.Value; 
      }
      scoreHighText.text = highScore.ToString(); 
   }
}

