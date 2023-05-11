using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Logro Data", menuName = "Logro Data")]
public class Logro_Data : ScriptableObject
{
    [SerializeField, Tooltip("String of total title in spanish")]
    private Sprite sprite;
    
    [SerializeField, Tooltip("String of total title in spanish")]
    private string title_es;

    [SerializeField, Tooltip("String of description in spanish")]
    private string description_es;
    
    [SerializeField, Tooltip("String of total title in spanish")]
    private string title_ca;

    [SerializeField, Tooltip("String of description in spanish")]
    private string description_ca;
    
    [SerializeField, Tooltip("String of total title in spanish")]
    private string title_en;

    [SerializeField, Tooltip("String of description in spanish")]
    private string description_en;
    
    [SerializeField, Tooltip("String of total title in spanish")]
    private string title_fr;

    [SerializeField, Tooltip("String of description in spanish")]
    private string description_fr;

    [SerializeField, Tooltip("Variable of int on display, number achieved")]
    private int numberVariable;
    
    [SerializeField, Tooltip("Bool to know if is completed, and if it need to be displayed")]
    private bool isCompleted;

    // Getters
    
    public Sprite Sprite => sprite;
    
    public string Title_Es => title_es;

    public string Description_Es => description_es;
    
    public string Title_Ca => title_ca;
    
    public string Description_Ca => description_ca;
    
    public string Title_En => title_en;

    public string Description_En => description_en;
    
    public string Title_Fr => title_fr;
    
    public string Description_Fr => description_fr;
    
    public int NumberVariable => numberVariable;

    public bool IsCompleted
    {
        get {return isCompleted; }
        set {isCompleted = value; }
    }
    
}
