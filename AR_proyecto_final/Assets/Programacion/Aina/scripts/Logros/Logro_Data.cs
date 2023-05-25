using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "new Logro Data", menuName = "Logro Data")]
public class Logro_Data : ScriptableObject
{
    public string type;
    
    public LocalizedString title;
    
    public LocalizedString description;

    public Sprite icon;

    [SerializeField, Tooltip("Variable of int on display, number achieved")]
    private int numberVariable;
    
    [SerializeField, Tooltip("Bool to know if is completed, and if it need to be displayed")]
    private bool isCompleted;

    // Getters

    public int NumberVariable => numberVariable;

    public bool IsCompleted
    {
        get {return isCompleted; }
        set {isCompleted = value; }
    }
    
}
