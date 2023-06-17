using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class EnemiesSpawnController : MonoBehaviour
{
    public bool randomMode = true; 
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
    public int autoEnemiesAmount = 6; 

    public GameObject FX_SummounCircle; 

    public List<GameObject> enemiesList; 

    private GameObject[] enemiesAlive; 
    private bool spawnControl; 
    int newWave = 0; 

    public TMP_Text txt_waveCount;  
    public Animator animatorWaveCount; 
    public GameObject go_waveCount; 
    public float timeCountShowUP = 0.1f; 

    private bool timeToWaveDisplay; 

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
        spawnControl = true; 
        timeToWaveDisplay = false; 
    }

    private void Update(){
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        if(randomMode && !timeToWaveDisplay){
            if(enemiesAlive.Length < autoEnemiesAmount && spawnControl){
                spawnControl = false; 
                StartCoroutine(SpawnEnemyRandom()); 
                //Debug.Log("spawned"); 
            }else{
                
                //Debug.Log(enemiesAlive.Length); 
            }
        }else{
            if(enemyKilled && !timeToWaveDisplay){
                SpawNewEnemy(); 
            }
        }
    }
    public void SpawNewEnemy(){
        // Level controller
        if(bodyCount == bodyCountToFirstNewWave){
            waveCount++; 
            bodyCountToFirstNewWave = bodyCountToFirstNewWave + newWaveEvery; 
            StartCoroutine(CD_DisplayWaveCount()); 
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
        //Debug.Log(bodyCount + " kill");
    }

    void EnemyStatsModifier(){
        enemiesList[waveCount].GetComponent<Enemy_A>().level = enemiesList[waveCount].GetComponent<Enemy_A>().level + levelUpAmout;  
    }

    private IEnumerator SpawnWithTime(){
        // Build random coordinates for spawn 
        float x = UnityEngine.Random.Range(x_LeftLimit, x_RightLimit); 
        float y = UnityEngine.Random.Range(y_DownLimit, y_UpLimit); 

        yield return new WaitForSeconds(enemiesList[waveCount].GetComponent<Enemy_A>().timeToRespawn);

        Instantiate(FX_SummounCircle, new Vector3(x, y, 0), Quaternion.identity);
        yield return new WaitForSeconds(enemiesList[waveCount].GetComponent<Enemy_A>().timeAfterFXSummon);
        Instantiate(enemiesList[waveCount], new Vector3(x, y, 0), Quaternion.identity);
    } 
    private IEnumerator SpawnEnemyRandom(){
        if(bodyCount == bodyCountToFirstNewWave){
            autoEnemiesAmount++; 
            bodyCountToFirstNewWave = bodyCountToFirstNewWave + newWaveEvery; 
            newWave++; 
            txt_waveCount.text = newWave.ToString(); 
            go_waveCount.SetActive(true); 
            StartCoroutine(CD_DisplayWaveCount()); 
            //animatorWaveCount.SetTrigger("show"); 
            Debug.Log("wave " + newWave); 
        }
        float x = UnityEngine.Random.Range(x_LeftLimit, x_RightLimit); 
        float y = UnityEngine.Random.Range(y_DownLimit, y_UpLimit); 

        yield return new WaitForSeconds(0.1f);

        Instantiate(FX_SummounCircle, new Vector3(x, y, 0), Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        int randomEnemy = UnityEngine.Random.Range(0, enemiesList.Count); 
        Instantiate(enemiesList[randomEnemy], new Vector3(x, y, 0), Quaternion.identity);

        spawnControl = true; 
    }
    IEnumerator CD_DisplayWaveCount(){
        timeToWaveDisplay = true; 
        yield return new WaitForSeconds(timeCountShowUP); 
        go_waveCount.SetActive(false); 
        timeToWaveDisplay = false; 
    }
}