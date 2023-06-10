using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class Mission_Fixed : MonoBehaviour
{
    public LocalizeStringEvent localizedStringEvent;
    public LocalizedString _LocalizedString;

    public IntVariable enemies = null;
    public FloatVariable time = null;

    public static Mission_Fixed instance;
    
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;
    
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

    private void Start()
    {
        // Keep track of the original so we dont change localizedString by mistake
        _LocalizedString = localizedStringEvent.StringReference;

        if (!_LocalizedString.TryGetValue("enemies", out var variable))
        {
            enemies = new IntVariable();
            _LocalizedString.Add("enemies", enemies);
        }
        else
        {
            enemies = variable as IntVariable;
        }
        
        if (!_LocalizedString.TryGetValue("time", out var variable2))
        {
            time = new FloatVariable();
            _LocalizedString.Add("time", time);
        }
        else
        {
            time = variable2 as FloatVariable;
        }
        
        // We can add a listener if we are interested in the Localized String.
        localizedStringEvent.OnUpdateString.AddListener(OnStringChanged);
    }

    public void RefreshFixedMission(bool nextPhase)
    {
        if (nextPhase)
        {
            ++indexList;
        }
        
        isCompleted = false;
        uiItem.transform.GetChild(1).gameObject.SetActive(false);
        MissionFixed_Data currentMission = fixedmissionList[indexList];
        enemiesToEliminate = currentMission.EnemiesToEliminate;
        maxTime = currentMission.MaxTime;
        
        Invoke("Parameters", 0.5f);

        uiItem.SetActive(true);

        Activate_CheckerMision();
    }
    
    void OnStringChanged(string s)
    {
        Debug.Log($"String changed to `{s}`");
    }
    
    private void Parameters()
    {
        enemies.Value = enemiesToEliminate;
        time.Value = maxTime;
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
                    uiItem.transform.GetChild(1).gameObject.SetActive(true);
                    yield break;
                }
                
                timer = 0;
                enemiesEliminated = 0;
            }
            
            yield return null;
        }
    }
}