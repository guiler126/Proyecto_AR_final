using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class Mission_Mana: MonoBehaviour
{
    public LocalizeStringEvent localizedStringEvent;
    public LocalizedString _LocalizedString;

    public IntVariable mana = null;
    
    public static Mission_Mana instance;
    
    [SerializeField, Tooltip("Bool to check if the mission is failed")]
    private bool isFailed;

    public GameObject uiItem;

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
        // Keep track of the original so we dont change localizedString by mistake
        _LocalizedString = localizedStringEvent.StringReference;

        if (!_LocalizedString.TryGetValue("mana", out var variable))
        {
            mana = new IntVariable();
            _LocalizedString.Add("mana", mana);
        }
        else
        {
            mana = variable as IntVariable;
        }
        
        // We can add a listener if we are interested in the Localized String.
        localizedStringEvent.OnUpdateString.AddListener(OnStringChanged);
    }
    
    void OnStringChanged(string s)
    {
        Debug.Log($"String changed to `{s}`");
    }

    public void RefreshManaMission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }

        isFailed = false;
        uiItem.transform.GetChild(1).gameObject.SetActive(true);
        MissionMana_Data currentMission = manamissionList[indexList];
        minMana = currentMission.MinMana;
        Invoke("Parameters", 0.5f);
    }
    
    public void Parameters()
    {
        mana.Value = minMana;
    }

    public void CheckFailedManaMission(float playerMana)
    {
        if (gameObject.activeInHierarchy)
        {
            uiItem.transform.GetChild(1).gameObject.SetActive(true);

            if (minMana > playerMana)
            {
                isFailed = true;
                --Sistema_Missions.instance.MissionsCompleted;
                uiItem.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
