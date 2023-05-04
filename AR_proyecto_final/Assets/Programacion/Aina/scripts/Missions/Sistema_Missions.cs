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

    public void Spawner()
    {        
        switch(Sistema_Oleadas.Instance.waveNumber)
        {
            case 0:
                MissionsEndRound();
                Mission_Fixed.instance.RefreshFixedMission();
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 1:
                Mission_Fixed.instance.RefreshFixedMission();
                RefreshAllMissions();
                SelectMissions();
                missionsCompleted = 2;
                break;
            case 2:
                Mission_Fixed.instance.RefreshFixedMission();
                SelectMissions();
                break;
            case 3:
                Mission_Fixed.instance.RefreshFixedMission();
                SelectMissions();
                break;
            case 4:
                Mission_Fixed.instance.RefreshFixedMission();
                SelectMissions();
                break;
            case 5:
                Mission_Fixed.instance.RefreshFixedMission();
                SelectMissions();
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

    public void RefreshAllMissions()
    {
        Mission_Mana.instance.RefreshManaMission();
        Mission_Habilitat1.instance.RefreshHabilitat1Mission();
        Mission_Habilitat2.instance.RefreshHabilitat2Mission();
        Mission_Dash.instance.RefreshDashMission();
    }
}
