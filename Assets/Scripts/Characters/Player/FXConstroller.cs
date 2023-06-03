using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class FXConstroller : MonoBehaviour
{
    public TMP_Text textLog; 
    public Animator canvasAnimator; 
    public static string log; 
    public static bool startLog; 
    public static string typeLog; 
    private string symbol; 
    private bool cd; 
    void Start()
    {
        cd = true; 

        startLog = false; 
    }

    void Update()
    {
        if(startLog){
            if(log != null && cd){
                cd = false; 
                StartCoroutine(Log()); 
            }
        }
    }
    IEnumerator Log(){
        textLog.text = log; 
        switch(typeLog)
        {
            case "life": 
                textLog.color = Color.red; 
                break; 
            case "score": 
                textLog.color = Color.yellow; 
                break; 
            default:
                textLog.color = Color.white; 
                break; 
        }
        canvasAnimator.SetTrigger("playerLog"); 
        yield return new WaitForSeconds(.5f); 
        log = null; 
        cd = true; 
        startLog = false; 
    }
    public static void SetLog(float text){
        log = text.ToString(); 
        startLog = true; 
    }
}