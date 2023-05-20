using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; 

public class SpeechController : MonoBehaviour
{
    public float textDisplayTime; 
    public TMP_Text mimicTextBox;  
    public TMP_Text playerTextBox;  
    public TMP_Text scoreTextBox;  
    public TMP_Text damageTextBox;  
    public TMP_Text hurtTextBox;  
    public TMP_Text dieTextBox;  

    Animator textAnimator; 

    private int mimicClickCount = 0; 

    private List<string> mimicSpeech; 
    public GameObject mimic; 

    void Start()
    {
        textAnimator = GetComponent<Animator>(); 
        mimicSpeech = mimic.GetComponent<MimicTalk>().clickTalk; 
    }
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.C)){
    //         animator.SetTrigger("talk"); 
    //     }
    //     if(log != null && cd){
    //         cd = false; 
    //         StartCoroutine(Log()); 
    //     }
    // }

    public void MimicSpeech(){
        StartCoroutine(textDisplayCD());
        mimicTextBox.text = mimicSpeech[mimicClickCount]; 
        mimicClickCount++; 
        if(mimicClickCount >= mimicSpeech.Count){
            mimicClickCount = 0; 
        }
    }
    IEnumerator textDisplayCD(){
        textAnimator.SetTrigger("fadeIn"); 
        yield return new WaitForSeconds(textDisplayTime); 
        textAnimator.SetTrigger("fadeOut");
    }
}
