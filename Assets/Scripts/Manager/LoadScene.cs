using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void NextScene(string nextSceneName){
        SceneManager.LoadScene(nextSceneName);
    }
}