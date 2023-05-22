using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pauseMenuPanel; 

    private void Awake() {
        gameIsPaused = false; 
        Time.timeScale = 1;
    }
    void Start(){
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseResume();
        }
    }
    public void PauseResume(){
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused){
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else{
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
