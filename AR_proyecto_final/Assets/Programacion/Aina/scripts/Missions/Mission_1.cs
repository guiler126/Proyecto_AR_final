using UnityEngine;


public class Mission_1 : Mission_Base
{
    [SerializeField, Tooltip("Indicator of total number of enemies that will be instantiated in that wave")]
    private int enemiesToEliminate;

    [SerializeField, Tooltip("Float variable of minimum waiting time between instances")]
    private float missionTime;

    // Getters
    
    public int EnemiesToEliminate => enemiesToEliminate;
    
    public float MissionTime => missionTime;
}
