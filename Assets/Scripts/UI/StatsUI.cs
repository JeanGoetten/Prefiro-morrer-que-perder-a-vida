using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    private StatsPlayer statsPlayer; 
    public Slider life; 
    public Slider power; 
    public Slider hungry; 
    void Start()
    {
        statsPlayer = GameObject.FindWithTag("Player").GetComponent<StatsPlayer>(); 

        life.maxValue = statsPlayer.life.BaseValue; 
        power.maxValue = statsPlayer.power.BaseValue; 
        hungry.maxValue = statsPlayer.hungry.BaseValue; 
    }

    // Update is called once per frame
    void Update()
    {
        life.value = statsPlayer.life.Value; 
        power.value = statsPlayer.power.Value; 
        hungry.value = statsPlayer.hungry.Value; 
    }
}
