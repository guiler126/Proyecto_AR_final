using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sistema_Spawn : MonoBehaviour
{
    
    [Header("----- Spawn Variables -----")]
    private float spawnTimer = 0.1f;
    private float timer = 0f;

    [Header("----- Enemies -----")] 
    [SerializeField] private GameObject prefab_Enemie;

    void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTimer)
        {
            Spawner();
        }
    }
 
    void Spawner()
    {
        Sistema_Oleadas sistemaOleadas = FindObjectOfType<Sistema_Oleadas>();

        if (sistemaOleadas.CheckEndRound())
        {
            return;
        }
        
        switch(sistemaOleadas.WaveNumber)
        {
            case 0://If waveNumber == 0
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(7f, 10f);
                --sistemaOleadas.TotalEnemies;
                break;//End switch
            case 1:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(5f, 7f);
                --sistemaOleadas.TotalEnemies;
                break;
            case 2:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(5f, 7f);
                --sistemaOleadas.TotalEnemies;
                break;
            case 3:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(4f, 5f);
                --sistemaOleadas.TotalEnemies;
                break;
            case 4:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(4f, 5f);
                --sistemaOleadas.TotalEnemies;
                break;
            case 5:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(5f, 7f);
                --sistemaOleadas.TotalEnemies;
                break;
            case 6:
                Instantiate(prefab_Enemie, gameObject.transform);
                spawnTimer = Random.Range(3f, 5f);
                --sistemaOleadas.TotalEnemies;
                break;
        }

        timer = 0f;
    }
}