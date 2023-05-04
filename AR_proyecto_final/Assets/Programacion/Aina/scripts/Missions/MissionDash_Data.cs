using UnityEngine;

[CreateAssetMenu(fileName = "new Mission Dash", menuName = "Mission Dash")]
public class MissionDash_Data: ScriptableObject
{
    [SerializeField, Tooltip("Maximum of times you can use the dash")]
    private int maxUses;
    
    // Getters
    
    public int MaxUses => maxUses;
}