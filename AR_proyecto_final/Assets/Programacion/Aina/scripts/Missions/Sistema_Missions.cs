using System;
using System.Collections.Generic;
using TMPro;
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

    public void StartMissionRound()
    {        
        switch(Sistema_Oleadas.Instance.waveNumber)
        {
            case 0:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(false);
                RefreshAllMissions(false);
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 1:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 2:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 3:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 4:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 5:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission(true);
                RefreshAllMissions(true);
                SelectMissions();
                missionsCompleted = 2;
                break;
        }
    }

    private void SelectMissions()
    {
        int sm = Random.Range(0, missionList.Count);
        missionList[sm].SetActive(true);
    }

    private void MissionsEndRound()
    {
        foreach (var mission in missionList)
        {
            mission.SetActive(false);
        }
    }

    public void RefreshAllMissions(bool nextPhase)
    {
        Mission_Mana.instance.RefreshManaMission(nextPhase);
        Mission_Habilitat1.instance.RefreshHabilitat1Mission(nextPhase);
        Mission_Habilitat2.instance.RefreshHabilitat2Mission(nextPhase);
        Mission_Dash.instance.RefreshDashMission(nextPhase);
    }
}
