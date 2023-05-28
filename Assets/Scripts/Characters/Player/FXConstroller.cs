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
        canvasAnimator.SetTrigger("playerLog"); 
        yield return new WaitForSeconds(.5f); 
        log = null; 
        cd = true; 
        startLog = false; 
    }
    public static void SetLog(string text){
        log = text; 
        startLog = true; 
    }
}
