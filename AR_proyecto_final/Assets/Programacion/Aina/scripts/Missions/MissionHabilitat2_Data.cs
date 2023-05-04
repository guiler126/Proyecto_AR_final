using UnityEngine;

[CreateAssetMenu(fileName = "new Mission Habilitat 2", menuName = "Mission Habilitat 2")]
public class MissionHabilitat2_Data: ScriptableObject
{
    [SerializeField, Tooltip("Maximum of times you can use the ability")]
    private int maxUses;
    
    // Getters
    
    public int MaxUses => maxUses;
}