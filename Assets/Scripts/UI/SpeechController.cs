using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; 

public class SpeechController : MonoBehaviour
{
    public float textDisplayTime; 
    public float intervalTime; 
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

    private bool cdController = true;

    void Start()
    {
        textAnimator = GetComponent<Animator>(); 
        mimicSpeech = mimic.GetComponent<MimicTalk>().clickTalk; 

        cdController = true; 
    }
    public void MimicSpeech(){
        if(cdController){
            cdController = false; 
            StartCoroutine(textDisplayCD());
            mimicTextBox.text = mimicSpeech[mimicClickCount]; 
            mimicClickCount++; 
            if(mimicClickCount >= mimicSpeech.Count){
                mimicClickCount = 0; 
            }
        }
    }
    IEnumerator textDisplayCD(){
        textAnimator.SetTrigger("fadeIn"); 
        yield return new WaitForSeconds(textDisplayTime); 
        textAnimator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(intervalTime); 
        cdController = true; 
    }
}
