using UnityEngine;

[CreateAssetMenu(fileName = "new Mission Fixed", menuName = "Mission Fixed")]
public class MissionFixed_Data: ScriptableObject
{
    [SerializeField, Tooltip("Indicator of total number of enemies that will be instantiated in that wave")]
    private int enemiesToEliminate;

    [SerializeField, Tooltip("Float variable of minimum waiting time between instances")]
    private float maxTime;

    // Getters
    
    public int EnemiesToEliminate => enemiesToEliminate;
    public float MaxTime => maxTime;
}