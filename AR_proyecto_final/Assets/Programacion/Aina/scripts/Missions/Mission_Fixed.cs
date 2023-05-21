using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Mission_Fixed : MonoBehaviour
{
    public static Mission_Fixed instance;
    
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;

    [SerializeField, Tooltip("Text to show at UI")]
    private TMP_Text descriptionTxt;

    [SerializeField, Tooltip("Index on lest list of the current mission")]
    private int indexList;
    
    [SerializeField, Tooltip("Number of enemies eliminated (not total)")]
    private int enemiesEliminated;
    
    [SerializeField, Tooltip("Number of enemies you need to eliminate to complete the mission")]
    private int enemiesToEliminate;    
    
    [SerializeField, Tooltip("Max time you have to kill the senemies (mission)")]
    private float maxTime;

    [Tooltip("List of Scriptable Object of Fixed Missions")]
    [SerializeField] private List<MissionFixed_Data> fixedmissionList;
    private IEnumerator currentCoroutine;

    // Getters
    
    public bool IsCompleted => isCompleted;
    
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
    }

    public void RefreshFixedMission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }
        
        isCompleted = false;
        MissionFixed_Data currentMission = fixedmissionList[indexList];
        enemiesToEliminate = currentMission.EnemiesToEliminate;
        maxTime = currentMission.MaxTime;
        descriptionTxt.text = $"{enemiesToEliminate}{maxTime}, {enemiesEliminated}";
        Activate_CheckerMision();
    }
    
    private void Activate_CheckerMision()
    {
        currentCoroutine = Coroutine_Check_MISSION();
        StartCoroutine(currentCoroutine);
    }    
    
    private void EndGame_CheckerMision()
    {
        if (!isCompleted)
        {
            --Sistema_Missions.instance.MissionsCompleted;
        }
    }
    
    IEnumerator Coroutine_Check_MISSION()
    {
        float timer = 0;

        while (!isCompleted)
        {
            timer += Time.deltaTime;
            
            if (enemiesEliminated >= enemiesToEliminate)
            {
                if (timer <= maxTime)
                {
                    isCompleted = true;
                    yield break;
                }
                
                timer = 0;
                enemiesEliminated = 0;
            }
            
            yield return null;
        }
    }
}