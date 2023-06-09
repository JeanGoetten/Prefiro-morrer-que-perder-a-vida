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
    public static bool enemyKilled; 
    private int waveCount = 0; 
    public int bodyCountToFirstNewWave = 6; 
    public int newWaveEvery = 6; 
    private float levelUpAmout = 0f; 
    public float levelUpIncrease = 0.1f; 
    // Options for first Spawn 
    public bool autoFirstSpawn = false; 
    public int autoEnemiesAmount = 0; 

    public List<GameObject> enemiesList; 

    private void Start() {

        bodyCount = 0; 
        levelUpAmout = 0f; 
        waveCount = 0; 

        if(autoFirstSpawn){
            for (int i = 0; i < autoEnemiesAmount; i++)
            {
                SpawNewEnemy(); 
            }
        }
    }

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

        // Make the last enemy the 'terror' enemy 
        if(waveCount > enemiesList.Count - 1){
            waveCount = enemiesList.Count  - 1; 
            levelUpAmout = levelUpAmout + levelUpIncrease; 

            //Increese some stat for the last enemy in the enemies list
            enemiesList[waveCount].GetComponent<Enemy_A>().level = 0; 
            EnemyStatsModifier(); 
        }

        // Instantiate the enemy with CD
        StartCoroutine(SpawnWithTime()); 

        // reset 'enemy killed moment' 
        enemyKilled = false; 
        Debug.Log(bodyCount + " kill");
    }

    void EnemyStatsModifier(){
        enemiesList[waveCount].GetComponent<Enemy_A>().level = enemiesList[waveCount].GetComponent<Enemy_A>().level + levelUpAmout;  
    }

    private IEnumerator SpawnWithTime(){
        // Build random coordinates for spawn 
        float x = Random.Range(x_LeftLimit, x_RightLimit); 
        float y = Random.Range(y_DownLimit, y_UpLimit); 

        yield return new WaitForSeconds(enemiesList[waveCount].GetComponent<Enemy_A>().timeToRespawn);

        Instantiate(enemiesList[waveCount], new Vector3(x, y, 0), Quaternion.identity);
    } 
}
