using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sistema_Spawn : MonoBehaviour
{

    // Singleton
    public static Sistema_Spawn Instance;
    
    [Header("----- Spawn Variables -----")]
    public PoolingItemsEnum enemyType;

    public WaveData current_wave;
    
    public List<Transform> spawnPoints;
    
    private IEnumerator currentCoroutine;

    public bool active_wave;
    private bool spawnBoss;
    private float spawnTimer = 5f;
    private float timer = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void StartSpawner()
    {
        currentCoroutine = Coroutine_StartSpawner();
        StartCoroutine(currentCoroutine);
    }

    IEnumerator Coroutine_StartSpawner()
    {
        spawnTimer = Random.Range(current_wave.SpawnTimer_min, current_wave.SpawnTimer_max);
        
        while (active_wave)
        {
            timer += Time.deltaTime;

            if(timer >= spawnTimer)
            {
                Spawner();
            }
            
            yield return null;
        }
    }

    void Spawner()
    {
        if (Sistema_Oleadas.Instance.CheckEndRound())
        {
            return;
        }
        
        GameObject enemy = PoolingManager.Instance.GetPooledObject((int)enemyType);

        if (enemy != null)
        {
            --Sistema_Oleadas.Instance.totalEnemies;
            
            // Get random spawn point from the list
            int spawnPoint_index = Random.Range(0, spawnPoints.Count);
            enemy.transform.position = spawnPoints[spawnPoint_index].position;
            enemy.gameObject.SetActive(true);
            
            spawnTimer = Random.Range(current_wave.SpawnTimer_min, current_wave.SpawnTimer_max);
        }

        if (Sistema_Oleadas.Instance.waveNumber == 15 && Sistema_Oleadas.Instance.totalEnemies >= 50 && !spawnBoss)
        {
            Boss_SPAWN.instance.Portal_Boss();
            spawnBoss = true;
        }

        timer = 0f;
    }
}