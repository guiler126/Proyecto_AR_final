using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Mission_Dash : MonoBehaviour
{
    public static Mission_Dash instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;
    
    [SerializeField, Tooltip("Text to show at UI")]
    private TMP_Text descriptionTxt;
    
    [SerializeField, Tooltip("Maximum of times you can use the dash")]
    private int maxUses;
    
    [SerializeField, Tooltip("Index on lest list of the current mission")]
    private int indexList;
    
    [SerializeField] private List<MissionDash_Data> dashmissionList;

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
    
    private void Start()
    {
        MissionDash_Data currentMission = dashmissionList[indexList];
        maxUses = currentMission.MaxUses;
    }
    
    public void RefreshDashMission()
    {
        ++indexList;
        
        isFailed = false;
        MissionDash_Data currentMission = dashmissionList[indexList];
        maxUses = currentMission.MaxUses;
        descriptionTxt.text = $"{maxUses}";
    }

    public void DeductMissionMaxUses()
    {
        --maxUses;
        
        if (maxUses == 0)
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
