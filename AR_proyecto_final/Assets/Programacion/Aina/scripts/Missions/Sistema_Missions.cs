using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sistema_Missions : MonoBehaviour
{
    public static Sistema_Missions instance;
    
    [Header("----- Mission Variables -----")]
    [SerializeField] private List<GameObject> missionList;

    private int missionsCompleted;
    
    public int MissionsCompleted
    {
        get {return missionsCompleted; }
        set {missionsCompleted = value; }
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
        StartMissionRound();
    }

    public void StartMissionRound()
    {        
        switch(Sistema_Oleadas.Instance.waveNumber)
        {
            case 0:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(false);
                RefreshAllMissions(false);
                SelectMissions();
                missionsCompleted = 0;
                break;
            case 1:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 0;
                break;
            case 2:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 0;
                break;
            case 3:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 0;
                break;
            case 4:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 0;
                break;
            case 5:
                MissionsEndRound();
                DeactivateUIMission();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 0;
                break;
        }
    }

    private void SelectMissions()
    {
        int sm = Random.Range(0, missionList.Count);
        missionList[sm].SetActive(true);
        
        if (missionList[sm].GetComponent<Mission_Mana>())
        {
            missionList[sm].GetComponent<Mission_Mana>().uiItem.SetActive(true);
        }
        else if (missionList[sm].GetComponent<Mission_Habilitat1>())
        {
            missionList[sm].GetComponent<Mission_Habilitat1>().uiItem.SetActive(true);
        }
        else if (missionList[sm].GetComponent<Mission_Habilitat2>())
        {
            missionList[sm].GetComponent<Mission_Habilitat2>().uiItem.SetActive(true);
        }
        else if (missionList[sm].GetComponent<Mission_Dash>())
        {
            missionList[sm].GetComponent<Mission_Dash>().uiItem.SetActive(true);
        }
    }

    private void MissionsEndRound()
    {
        foreach (var mission in missionList)
        {
            if (mission.activeInHierarchy)
            {
                mission.SetActive(false);
            }
        }
    }
    
    private void DeactivateUIMission()
    {
        Mission_Mana.instance.uiItem.SetActive(false);
        Mission_Habilitat1.instance.uiItem.SetActive(false);
        Mission_Habilitat2.instance.uiItem.SetActive(false);
        Mission_Dash.instance.uiItem.SetActive(false);
    }

    private void RefreshAllMissions(bool nextPhase)
    {
        Mission_Mana.instance.RefreshManaMission(nextPhase);
        Mission_Habilitat1.instance.RefreshHabilitat1Mission(nextPhase);
        Mission_Habilitat2.instance.RefreshHabilitat2Mission(nextPhase);
        Mission_Dash.instance.RefreshDashMission(nextPhase);
    }
}
