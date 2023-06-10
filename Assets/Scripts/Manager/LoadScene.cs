using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public Animator anim; 
    new public AudioSource audio; 
    public AudioClip btn_Start; 

    public void NextScene(string nextSceneName){
        audio.Stop(); 
        audio.PlayOneShot(btn_Start); 
        anim.SetTrigger("fadeIn"); 
        StartCoroutine(LoadNextScene(nextSceneName)); 
        
    }
    IEnumerator LoadNextScene(string nextSceneName){
        yield return new WaitForSeconds(btn_Start.length); 
        SceneManager.LoadScene(nextSceneName);
    }
}