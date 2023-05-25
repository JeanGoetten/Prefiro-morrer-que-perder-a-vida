using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
    public float x_RightLimit;
    public float x_LeftLimit;
    public float y_UpLimit;  
    public float y_DownLimit; 
    public static int bodyCount = 0; 
    private int _bodyCount = 0; 
    public static bool enemyKilled; 
    private int waveCount = 0; 
    public int bodyCountToFirstNewWave = 6; 
    public int newWaveEvery = 6; 
    public List<GameObject> enemiesList; 

    private void Update(){
        if(enemyKilled){
            SpawNewEnemy(); 
        }
    }
    public void SpawNewEnemy(){
        // Level controller
        if(bodyCount == bodyCountToFirstNewWave){
            waveCount++; 
            bodyCountToFirstNewWave = bodyCountToFirstNewWave + newWaveEvery; 
        }
        



        // Build random coordinates for spawn 
        float x = Random.Range(x_LeftLimit, x_RightLimit); 
        float y = Random.Range(y_DownLimit, y_UpLimit); 

        // Make the last enemy the 'terror' enemy 
        if(waveCount > enemiesList.Count - 1){
            waveCount = enemiesList.Count  - 1; 

            //Increese some stat for the last enemy in the enemies list
            EnemyStatsModifier(); 
        }

        // Instantiate the enemy 
        Instantiate(enemiesList[waveCount], new Vector3(x, y, 0), Quaternion.identity);

        // reset 'enemy killed moment' 
        enemyKilled = false; 
        Debug.Log(bodyCount + " kill");
    }

    void EnemyStatsModifier(){
        enemiesList[waveCount].GetComponent<Enemy_A>().moveSpeed = enemiesList[waveCount].GetComponent<Enemy_A>().moveSpeed + 1f;  
    }
}
