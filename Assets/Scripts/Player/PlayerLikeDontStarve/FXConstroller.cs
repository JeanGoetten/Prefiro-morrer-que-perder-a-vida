using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXConstroller : MonoBehaviour
{
    public Text textLog; 
    Animator animator; 
    public static string log; 
    private string symbol; 
    private bool cd; 
    void Start()
    {
        animator = GetComponent<Animator>(); 
        cd = true; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            animator.SetTrigger("talk"); 
        }
        if(log != null && cd){
            cd = false; 
            StartCoroutine(Log()); 
        }
    }
    IEnumerator Log(){
        textLog.text = log; 
        animator.SetTrigger("playerLog"); 
        yield return new WaitForSeconds(0.3f); 
        log = null; 
        cd = true; 
    }
}
