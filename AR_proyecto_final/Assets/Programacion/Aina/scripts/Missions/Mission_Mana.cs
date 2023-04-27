using System;
using UnityEngine;


public class Mission_Mana: MonoBehaviour
{
    [SerializeField, Tooltip("Indicator of total number of enemies that will be instantiated in that wave")]
    private bool isFailed;

    // Getters
    
    public bool IsFailed => isFailed;

    private void Update()
    {
        if (isFailed) return;
    }
}
