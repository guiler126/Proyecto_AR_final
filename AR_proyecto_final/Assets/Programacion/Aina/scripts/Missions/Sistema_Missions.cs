using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sistema_Missions : MonoBehaviour
{
    [Header("----- Mission Variables -----")]

    [SerializeField] private TMP_Text missionText_1;
    [SerializeField] private TMP_Text missionText_2;
    [SerializeField] private TMP_Text missionText_3;

    public void Spawner()
    {        
        switch(Sistema_Oleadas.Instance.waveNumber)
        {
            case 0:
                SelectMissions();
                break;
            case 1:
                break;
        }
    }

    private void SelectMissions()
    {
        //int sm = Random.Range(0, missionList.Count);
    }
}
