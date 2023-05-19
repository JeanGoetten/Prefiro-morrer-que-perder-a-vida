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
    public float statsModifierHungry = .01f; 
    [SerializeField]
    public float statsModifierGold = .01f; 
    
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
    public bool hungryStat; 
    [SerializeField]
    public bool goldStat;
    [SerializeField]
    public float goldValue = .01f;  
    //Mouse events
    public UnityEvent leftClick;
    //public UnityEvent middleClick; //(if use middle mouse button)
    public UnityEvent rightClick;
    private void Start() {
        statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 
    }
    public void DropItem(){
        statsPlayer.gold.AddModifier(new StatModifier(goldValue, StatModType.Flat)); 
        FXConstroller.log = "+" + goldValue.ToString() + " gold"; 
        Destroy(this.gameObject);
    }
    public void UseItem(){
        if(lifeStat){
            if(flat){
                statsPlayer.life.AddModifier(new StatModifier(statsModifierLife, StatModType.Flat)); 
            }else if(percent){
                statsPlayer.life.AddModifier(new StatModifier(statsModifierLife, StatModType.PercentAdd)); 
            } 
            if(statsModifierLife > 0){
                FXConstroller.log = "+" + statsModifierLife.ToString() + " life"; 
            }else{
                FXConstroller.log = statsModifierLife.ToString() + " life"; 
            }
        }
        if(powerStat){
            statsPlayer.power.AddModifier(new StatModifier(statsModifierPower, StatModType.Flat)); 
            if(statsModifierPower > 0){
                FXConstroller.log = "+" + statsModifierPower.ToString() + " power"; 
            }else{
                FXConstroller.log = statsModifierPower.ToString() + " power"; 
            }
        }
        if(hungryStat){
            statsPlayer.hungry.AddModifier(new StatModifier(statsModifierHungry, StatModType.Flat)); 
            if(statsModifierHungry > 0){
                FXConstroller.log = "+" + statsModifierHungry.ToString() + " hungry"; 
            }else{
                FXConstroller.log = statsModifierHungry.ToString() + " hungry"; 
            }
        }
        if(goldStat){
            statsPlayer.gold.AddModifier(new StatModifier(statsModifierGold, StatModType.Flat)); 
            if(statsModifierGold > 0){
                FXConstroller.log = "+" + statsModifierGold.ToString() + " gold"; 
            }else{
                FXConstroller.log = statsModifierGold.ToString() + " gold"; 
            }
        }
        Destroy(this.gameObject);
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
