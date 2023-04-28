using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mission_Fixed : MonoBehaviour
{
    public static Mission_Fixed instance;
    
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;
    
    [SerializeField, Tooltip("String with the title, description of the mission")]
    private string description;

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
        Activate_CheckerMision();
    }

    public void RefreshFixedMission()
    {
        ++indexList;
        
        MissionFixed_Data currentMission = fixedmissionList[indexList];
        enemiesToEliminate = currentMission.EnemiesToEliminate;
        maxTime = currentMission.MaxTime;
        Activate_CheckerMision();
    }
    
    private void Activate_CheckerMision()
    {
        currentCoroutine = Coroutine_Check_MISSION();
        StartCoroutine(currentCoroutine);
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