using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Main.CharacterStats; 

public class ItemStat : MonoBehaviour, IPointerClickHandler 
{
    [Header("Stats Effected QTD")]
    private StatsPlayer statsPlayer; 
    [SerializeField]
    public float statsModifierLife = .01f; 
    [SerializeField]
    public float statsModifierPower = .01f; 
    [SerializeField]
    public float statsModifierSpeed = .01f; 
    [SerializeField]
    public float statsModifierScore = .01f; 
    
    [Header("Modifier Type")]
    [SerializeField]
    private bool flat = true; 
    [SerializeField]
    private bool percent; 
    [Header("Modifier Stat")]
    [SerializeField]
    public bool lifeStat = true; 
    [SerializeField]
    public bool powerStat; 
    [SerializeField]
    public bool speedStat; 
    [SerializeField]
    public bool scoreStat;
    [SerializeField]
    public float scoreValue = 0f;  
    //Mouse events
    public UnityEvent leftClick;
    //public UnityEvent middleClick; //(if use middle mouse button)
    public UnityEvent rightClick;
    private void Start() {
        statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 
    }
    public void DropItem(){
        statsPlayer.score.AddModifier(new StatModifier(scoreValue, StatModType.Flat)); 
        FXConstroller.SetLog("+" + scoreValue.ToString() + " points");
        //Destroy(this.gameObject);
    }
    public void UseItem(){
        if(lifeStat){
            if(flat){
                statsPlayer.life.AddModifier(new StatModifier(statsModifierLife, StatModType.Flat)); 
            }else if(percent){
                statsPlayer.life.AddModifier(new StatModifier(statsModifierLife, StatModType.PercentAdd)); 
            } 
            if(statsModifierLife > 0){
                FXConstroller.SetLog("+" + statsModifierLife.ToString() + " life"); 
            }else{
                FXConstroller.SetLog(statsModifierLife.ToString() + " life"); 
            } 
        }
        if(powerStat){
            statsPlayer.power.AddModifier(new StatModifier(statsModifierPower, StatModType.Flat)); 
            if(statsModifierPower > 0){
                FXConstroller.SetLog("+" + statsModifierPower.ToString() + " power"); 
            }else{
                FXConstroller.SetLog(statsModifierPower.ToString() + " power"); 
            }
        }
        if(speedStat){
            statsPlayer.speed.AddModifier(new StatModifier(statsModifierSpeed, StatModType.Flat)); 
            if(statsModifierSpeed > 0){
                FXConstroller.SetLog("+" + statsModifierSpeed.ToString() + " speed"); 
            }else{
                FXConstroller.SetLog(statsModifierSpeed.ToString() + " speed"); 
            }
        }
        if(scoreStat){
            statsPlayer.score.AddModifier(new StatModifier(statsModifierScore, StatModType.Flat)); 
            if(statsModifierScore > 0){
                FXConstroller.SetLog("+" + statsModifierScore.ToString() + " score"); 
            }else{
                FXConstroller.SetLog(statsModifierScore.ToString() + " score"); 
            }
        }
        //Destroy(this.gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
     {
         if (eventData.button == PointerEventData.InputButton.Left)
             leftClick.Invoke();
        //  else if (eventData.button == PointerEventData.InputButton.Middle)
        //      middleClick.Invoke();
         else if (eventData.button == PointerEventData.InputButton.Right)
             rightClick.Invoke();
      }
}
