using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Missions : MonoBehaviour
{
    [Header("----- Mission Variables -----")]
    public List <Mission_Base> missionList;

    public void Spawner()
    {        
        switch(Sistema_Oleadas.Instance.waveNumber)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }
}
