using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
    public static int bodyCount; 
    public static bool enemyKilled; 
    public int waveCount = 0; 
    public List<GameObject> enemiesList; 

    private void Update(){
        if(enemyKilled){
            SpawNewEnemy(); 
        }
    }
    public void SpawNewEnemy(){
        float x = Random.Range(-12.5f, 13f); 
        float y = Random.Range(22.5f, 49f); 
        Instantiate(enemiesList[0], new Vector3(x, y, 0), Quaternion.identity);
        enemyKilled = false; 
        Debug.Log(bodyCount + " kill");
    }
}
