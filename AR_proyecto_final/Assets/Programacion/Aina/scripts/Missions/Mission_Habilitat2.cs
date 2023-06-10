using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class Mission_Habilitat2 : MonoBehaviour
{
    public LocalizeStringEvent localizedStringEvent;
    public LocalizedString _LocalizedString;

    public IntVariable uses = null;
    
    public static Mission_Habilitat2 instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;

    public GameObject uiItem;

    [SerializeField, Tooltip("Maximum of times you can use the ability")]
    private int maxUses;
    
    [SerializeField, Tooltip("Index on lest list of the current mission")]
    private int indexList;
    
    [SerializeField] private List<MissionHabilitat2_Data> ability2missionList;

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
        // Keep track of the original so we dont change localizedString by mistake
        _LocalizedString = localizedStringEvent.StringReference;

        if (!_LocalizedString.TryGetValue("uses", out var variable))
        {
            uses = new IntVariable();
            _LocalizedString.Add("uses", uses);
        }
        else
        {
            uses = variable as IntVariable;
        }
        
        // We can add a listener if we are interested in the Localized String.
        localizedStringEvent.OnUpdateString.AddListener(OnStringChanged);
    }
    
    void OnStringChanged(string s)
    {
        Debug.Log($"String changed to `{s}`");
    }

    public void RefreshHabilitat2Mission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }
        
        isFailed = false;
        uiItem.transform.GetChild(1).gameObject.SetActive(true);
        MissionHabilitat2_Data currentMission = ability2missionList[indexList];
        maxUses = currentMission.MaxUses;
        Invoke("Parameters", 0.5f);
    }
    
    public void Parameters()
    {
        uses.Value = maxUses;
    }

    public void DeductMissionMaxUses()
    {
        if (gameObject.activeInHierarchy)
        {
            --maxUses;
            
            Invoke("Parameters", 0.5f);
            uiItem.transform.GetChild(1).gameObject.SetActive(true);

            if (maxUses == 0)
            {
                isFailed = true;
                --Sistema_Missions.instance.MissionsCompleted;
                uiItem.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
