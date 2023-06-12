using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Sistema_Spawn : MonoBehaviour
{

    // Singleton
    public static Sistema_Spawn Instance;
    
    [Header("----- Spawn Variables -----")]
    public PoolingItemsEnum enemyType;
    public PoolingItemsEnum enemyPortal;

    public WaveData current_wave;
    
    public List<Transform> spawnPoints;
    
    private IEnumerator currentCoroutine;

    public bool active_wave;
    private bool spawnBoss;
    private float spawnTimer = 5f;
    private float timer = 0f;

    [SerializeField] private float timeSpawnEnemy;

    private GameObject enemy;
    private GameObject portal;

    [SerializeField] private List<AudioClip> spawnSound;

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
        
        portal = PoolingManager.Instance.GetPooledObject((int)enemyPortal);
        int spawnPoint_index = Random.Range(0, spawnPoints.Count);

        if (portal != null)
        {
            portal.transform.position = new Vector3(spawnPoints[spawnPoint_index].position.x, 0.01f, spawnPoints[spawnPoint_index].position.z);
            portal.gameObject.SetActive(true);
        }
        
        enemy = PoolingManager.Instance.GetPooledObject((int)enemyType);

        if (enemy != null)
        {
            --Sistema_Oleadas.Instance.totalEnemies;
            enemy.transform.position = spawnPoints[spawnPoint_index].position;
            enemy.gameObject.SetActive(true);
            
            spawnTimer = Random.Range(current_wave.SpawnTimer_min, current_wave.SpawnTimer_max);
        }

        SoundSpawn();
        
        Invoke("SpawnEnemy", timeSpawnEnemy);

        if (Sistema_Oleadas.Instance.waveNumber == 15 && Sistema_Oleadas.Instance.totalEnemies >= 50 && !spawnBoss)
        {
            Boss_SPAWN.instance.Portal_Boss();
            spawnBoss = true;
            SoundSpawn();
            AudioManager.instance.ChangeBackgroundMusic(spawnSound[2]);
        }

        timer = 0f;
    }

    private void SpawnEnemy()
    {
        portal.SetActive(false);
        enemy.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void SoundSpawn()
    {
        var _index = Random.Range(0, 1);
        
        AudioManager.instance.PlayEffectSound(spawnSound[_index]);
    }
}