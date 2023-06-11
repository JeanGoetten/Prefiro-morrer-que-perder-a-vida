using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Enemy_Die : MonoBehaviour
{
    new AudioSource audio; 
    public AudioClip SFX_clipToDie; 
    public bool SFX_Time; 
    public float manualTime = 0.1f; 
    void Start()
    {
        audio = GetComponent<AudioSource>(); 
        audio.PlayOneShot(SFX_clipToDie); 
        StartCoroutine(CD_To_Die()); 
    }
    IEnumerator CD_To_Die(){
        if(SFX_Time){
            yield return new WaitForSeconds(SFX_clipToDie.length); 
        }else{
            yield return new WaitForSeconds(manualTime); 
        }
        Destroy(this.gameObject); 
    }
}
