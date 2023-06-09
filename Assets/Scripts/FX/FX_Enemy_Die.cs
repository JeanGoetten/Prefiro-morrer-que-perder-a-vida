using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Enemy_Die : MonoBehaviour
{
    new AudioSource audio; 
    public AudioClip SFX_clipToDie; 
    void Start()
    {
        audio = GetComponent<AudioSource>(); 
        audio.PlayOneShot(SFX_clipToDie); 
    }
    IEnumerator CD_To_Die(){
        yield return new WaitForSeconds(SFX_clipToDie.length); 
        Destroy(this.gameObject); 
    }
}
