using System;
using System.Collections.Generic;
using UnityEngine;


public class Mission_Mana: MonoBehaviour
{
    public static Mission_Mana instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;    
    
    [SerializeField, Tooltip("Minimum mana you need to have")]
    private int minMana;
    
    [SerializeField, Tooltip("Index on lest list of the current mission")]
    private int indexList;
    
    [SerializeField] private List<MissionMana_Data> manamissionList;

    // Getters
    
    public bool IsFailed => isFailed;

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

    private void Update()
    {
        if (isFailed) return;
    }
    
    public void RefreshFixedMission()
    {
        ++indexList;
        
        MissionMana_Data currentMission = manamissionList[indexList];
        minMana = currentMission.MinMana;
    }
}
