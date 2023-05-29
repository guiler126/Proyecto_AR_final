using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Mission_Habilitat1 : MonoBehaviour
{
    public static Mission_Habilitat1 instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;
    
    [SerializeField, Tooltip("Text to show at UI")]
    private TMP_Text descriptionTxt;
    public GameObject uiItem;

    [SerializeField, Tooltip("Maximum of times you can use the ability")]
    private int maxUses;
    
    [SerializeField, Tooltip("Index of the list of the current mission")]
    private int indexList;
    
    [SerializeField] private List<MissionHabilitat1_Data> ability1missionList;

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

    public void RefreshHabilitat1Mission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }
        
        isFailed = false;
        MissionHabilitat1_Data currentMission = ability1missionList[indexList];
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
                --Sistema_Missions.instance.MissionsCompleted;
                uiItem.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
