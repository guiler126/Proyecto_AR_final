using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "new Logro Data", menuName = "Logro Data")]
public class Logro_Data : ScriptableObject
{
    public LocalizedString title;
    
    public Sprite icon;

    [SerializeField, Tooltip("Variable of int on display, number achieved")]
    public int numberVariable;
    
    public int numberTotal_1;
    
    public int numberTotal_2;
    
    public int numberTotal_3;
}
