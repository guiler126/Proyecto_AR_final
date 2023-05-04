using UnityEngine;

[CreateAssetMenu(fileName = "new Mission Habilitat 1", menuName = "Mission Habilitat 1")]
public class MissionHabilitat1_Data: ScriptableObject
{
    [SerializeField, Tooltip("Maximum of times you can use the ability")]
    private int maxUses;
    
    // Getters
    
    public int MaxUses => maxUses;
}