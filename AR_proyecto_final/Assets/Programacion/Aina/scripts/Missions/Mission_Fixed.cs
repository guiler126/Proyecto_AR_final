using System;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Fixed : MonoBehaviour
{
    public static Mission_Fixed instance;
    
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;
    
    [SerializeField, Tooltip("String with the title, description of the mission")]
    private string description;

    private int indexList;
    
    private int enemiesToEliminate;    
    
    private float maxTime;
    private float currentTime;

    [SerializeField] private List<MissionFixed_Data> fixedmissionList;

    // Getters
    
    public bool IsCompleted => isCompleted;
    public string Description => description;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        MissionFixed_Data currentMission = fixedmissionList[indexList];
        enemiesToEliminate = currentMission.EnemiesToEliminate;
        maxTime = currentMission.MaxTime;
    }

    public void RefreshFixedMission()
    {
        ++indexList;
        
        MissionFixed_Data currentMission = fixedmissionList[indexList];
        enemiesToEliminate = currentMission.EnemiesToEliminate;
        maxTime = currentMission.MaxTime;
    }
}