using UnityEngine;

public abstract class Mission_Base
{
    [SerializeField, Tooltip("Checker of mission has been completed")]
    private bool isCompleted;

    [SerializeField, Tooltip("String with the title, description of the mission")]
    private string description;

    // Getters
    
    public bool IsCompleted => isCompleted;
    public string Description
    {
        get {return description; }
        set {description = value; }
    }
    
    public void CheckMission()
    {
        
    }
}