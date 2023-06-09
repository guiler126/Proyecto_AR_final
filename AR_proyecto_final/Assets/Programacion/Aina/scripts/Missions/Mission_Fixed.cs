using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class Mission_Fixed : MonoBehaviour
{
    public LocalizeStringEvent localizedStringEvent;
    public LocalizedString _LocalizedString;

    public IntVariable playerScore = null;
    public StringVariable nameNew = null;

    public static Mission_Fixed instance;
    
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;

    [SerializeField, Tooltip("Text to show at UI")]
    private TMP_Text descriptionTxt;
    [SerializeField] private GameObject uiItem;

    [SerializeField, Tooltip("Index on lest list of the current mission")]
    private int indexList;

    [SerializeField, Tooltip("Number of enemies you need to eliminate to complete the mission")]
    private int enemiesToEliminate;
    private int enemiesEliminated;    
    
    [SerializeField, Tooltip("Max time you have to kill the senemies (mission)")]
    private float maxTime;

    [Tooltip("List of Scriptable Object of Fixed Missions")]
    [SerializeField] private List<MissionFixed_Data> fixedmissionList;
    private IEnumerator currentCoroutine;

    public int EnemiesEliminated
    {
        get {return enemiesEliminated; }
        set {enemiesEliminated = value; }
    }
    
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
        uiItem.SetActive(true);

        Activate_CheckerMision();
    }
    
    void OnStringChanged(string s)
    {
        Debug.Log($"String changed to `{s}`");
    }


    [ContextMenu("test")]
    public void TEST()
    {

        // Keep track of the original so we dont change localizedString by mistake
        _LocalizedString = localizedStringEvent.StringReference;

        if (!_LocalizedString.TryGetValue("age", out var variable))
        {
            playerScore = new IntVariable();
            _LocalizedString.Add("age", playerScore);
        }
        else
        {
            playerScore = variable as IntVariable;
        }
        
        if (!_LocalizedString.TryGetValue("name", out var variable2))
        {
            nameNew = new StringVariable();
            _LocalizedString.Add("name", nameNew);
        }
        else
        {
            nameNew = variable2 as StringVariable;
        }
        
        // We can add a listener if we are interested in the Localized String.
        localizedStringEvent.OnUpdateString.AddListener(OnStringChanged);
    }
    
    [ContextMenu("test")]
    public void TEST2()
    {
        playerScore.Value = 2;
        nameNew.Value = "carlos";
    }
    
    public void TEST3()
    {
        playerScore.Value = 3;
        nameNew.Value = "ruben";
    }

    private void Activate_CheckerMision()
    {
        currentCoroutine = Coroutine_Check_MISSION();
        StartCoroutine(currentCoroutine);
    }    
    
    public void EndGame_CheckerMision()
    {
        if (isCompleted)
        {
            ++Sistema_Missions.instance.MissionsCompleted;
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
                    uiItem.transform.GetChild(2).gameObject.SetActive(true);
                    yield break;
                }
                
                timer = 0;
                enemiesEliminated = 0;
            }
            
            yield return null;
        }
    }
}