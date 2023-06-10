using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public Animator anim; 
    new public AudioSource audio; 
    public AudioClip btn_Start; 

    public GameObject loadingScreen; 
    public Slider loadingBarFill; 

    public void NextScene(string nextSceneName){
        Time.timeScale = 1;
        audio.Stop(); 
        audio.PlayOneShot(btn_Start); 
        anim.SetTrigger("fadeIn"); 

        StartCoroutine(LoadNextScene(nextSceneName)); 
        
    }
    IEnumerator LoadNextScene(string nextSceneName){
        loadingScreen.SetActive(true); 
        yield return new WaitForSeconds(btn_Start.length); 
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName); 
        

        while(!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadingBarFill.value = progressValue; 

            yield return null;  
        }   
    }
}