using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sistema_Oleadas : MonoBehaviour
{
    public static Sistema_Oleadas instance;
    
    [Header("----- Variables -----")]
    
    [Tooltip("Ona actual")]
    private int waveNumber = 0;
    
    [Tooltip("Nombre d'enemics total en la ona")]
    private int totalEnemies;
    
    [Tooltip("Nombre d'enemics que el player ha eliminat")]
    private int defeatedEnemies;
    
    [Tooltip("Tems d'espera entre una ronda i un altre")]
    private float timeBetweenRounds = 30;
    
    public bool CheckEndRound()
    {
        if (totalEnemies <= 0)
        {
            return true;
        }
        
        return false;
    }
    
    public int WaveNumber
    {
        get {return waveNumber; }
    }
    
    public int TotalEnemies
    {
        get {return totalEnemies; }
        set {totalEnemies = value; }
    }
    
    public int DefeatedEnemies
    {
        get {return defeatedEnemies; }
        set {defeatedEnemies = value; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Checker();
    }
    
    void Checker()
    {
        switch(waveNumber)
        {
            case 0://If waveNumber == 0
                totalEnemies = 10;
                break;//End switch
            case 1:
                totalEnemies = 18;
                break;
            case 2:
                totalEnemies = 25; 
                break;
            case 3:
                totalEnemies = 32;
                break;
            case 4:
                totalEnemies = 45;
                break;
            case 5:
                totalEnemies = 55;
                break;
            case 6:
                totalEnemies = 65;
                break;
        }
        
        if (CheckEndRound() && waveNumber != 6)
        {
            ++waveNumber; //Increment by 1. Same as:  waveNumber = waveNumber + 1;
        }
    }
}

