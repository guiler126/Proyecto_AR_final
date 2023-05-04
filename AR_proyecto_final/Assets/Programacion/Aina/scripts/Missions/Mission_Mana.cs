using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Mission_Mana: MonoBehaviour
{
    public static Mission_Mana instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;
    
    [SerializeField, Tooltip("Text to show at UI")]
    private TMP_Text descriptionTxt;
    
    [SerializeField, Tooltip("Minimum mana you need to have")]
    private int minMana;
    
    [SerializeField, Tooltip("Index of the list of the current mission")]
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

    private void Start()
    {
        MissionMana_Data currentMission = manamissionList[indexList];
        minMana = currentMission.MinMana;
    }

    public void RefreshManaMission()
    {
        ++indexList;

        isFailed = false;
        MissionMana_Data currentMission = manamissionList[indexList];
        minMana = currentMission.MinMana;
        descriptionTxt.text = $"{minMana}";
    }

    public void CheckFailedManaMission()
    {
        //add vaiable mana player 
        if (minMana <= 0)
        {
            isFailed = true;
            if (gameObject.activeInHierarchy)
            {
                --Sistema_Missions.instance.MissionsCompleted;
            }
            gameObject.SetActive(false);
        }
    }
}
