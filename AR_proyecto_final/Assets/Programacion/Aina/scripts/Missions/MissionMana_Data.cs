using UnityEngine;

[CreateAssetMenu(fileName = "new Mission Mana", menuName = "Mission Mana")]
public class MissionMana_Data: ScriptableObject
{
    [SerializeField, Tooltip("Minimum mana you need to have all the time")]
    private int minMana;
    
    // Getters
    
    public int MinMana => minMana;
}