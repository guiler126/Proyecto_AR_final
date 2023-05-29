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
    public GameObject uiItem;

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

    public void RefreshDashMission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }
        
        isFailed = false;
        MissionDash_Data currentMission = dashmissionList[indexList];
        maxUses = currentMission.MaxUses;
        descriptionTxt.text = $"{maxUses}";
    }

    public void DeductMissionMaxUses()
    {
        if (gameObject.activeInHierarchy)
        {
            --maxUses;
            descriptionTxt.text = $"{maxUses}";
            uiItem.transform.GetChild(2).gameObject.SetActive(true);

            if (maxUses == 0)
            {
                isFailed = true;
                ++Sistema_Missions.instance.MissionsCompleted;
                uiItem.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
