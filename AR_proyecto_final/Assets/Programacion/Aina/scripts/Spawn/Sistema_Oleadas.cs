using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sistema_Oleadas : MonoBehaviour
{
    
    // Singleton
    public static Sistema_Oleadas Instance;
    
    [Header("----- Variables -----")] 
    public List<WaveData> waveData_list;

    [Tooltip("Current Wave")]
    public int waveNumber = 0;
    
    [Tooltip("Total number of enemies in the wave")]
    public int totalEnemies;

    private bool firstRound;

    public bool CheckEndRound()
    {
        if (totalEnemies <= 0)
        {
            return true;
        }
        
        return false;
    }
    
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

    private void Start()
    {
        Checker();
    }

    public void StartRound()
    {
        StartWave();
        
        Sistema_Spawn.Instance.active_wave = true;
        Sistema_Spawn.Instance.StartSpawner();
    }
    
    void StartWave()
    {
        if (waveData_list != null && waveData_list.Count > 0)
        {
            totalEnemies = waveData_list[waveNumber].TotalEnemies;
            Sistema_Spawn.Instance.current_wave = waveData_list[waveNumber];
            GameManager.instance.TotalEnemies = totalEnemies;
        }
    }
    
    public void Checker()
    {
        if (CheckEndRound() && waveNumber != waveData_list.Count && firstRound)
        {
            ++waveNumber;
        }
        
        StartRound();
        firstRound = true;
    }
}

