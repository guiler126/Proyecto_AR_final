using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Logros : MonoBehaviour
{
    public static Sistema_Logros instance;

    [Header("----- General Variables -----")]
    public bool endGame;
    private int achievementLvl;
    private IEnumerator currentCoroutine;

    [Header("----- Damage Caused Variables -----")]
    [Tooltip("Int variable of number of damage the player did too the enemies")]
    private int damageCaused;
    [SerializeField] private Sprite damageCaused_sprite;
    
    [Header("----- Attack 1 Variables -----")]
    [Tooltip("Int variable of number of times the player used the main attack")]
    private int attack1UsedTimes;
    
    [Header("----- Attack 2 Variables -----")]
    [Tooltip("Int variable of number of times the player used the second attack")]
    private int attack2UsedTimes;
    
    [Header("----- Dash Variables -----")]
    [Tooltip("Int variable of number of times the player used the dash")]
    private int dashUsedTimes;
    
    [Header("----- Total Time Variables -----")]
    [Tooltip("Float variable of total time the player took to complete the game")]
    private float totalTime;
    
    [Header("----- Sounds List -----")]
    [SerializeField] private GameObject content_logros_list;
    [SerializeField] private Item_logros_list item_logros_list;

    // Get Set
    
    public int DamageCaused
    {
        get {return damageCaused; }
        set {damageCaused = value; }
    }    
    
    public int Attack1UsedTimes
    {
        get {return attack1UsedTimes; }
        set {attack1UsedTimes = value; }
    }
    
    public int Attack2UsedTimes
    {
        get {return attack2UsedTimes; }
        set {attack2UsedTimes = value; }
    }    
    
    public int DashUsedTimes
    {
        get {return dashUsedTimes; }
        set {dashUsedTimes = value; }
    }
    
    public float TotalTime
    {
        get {return totalTime; }
        set {totalTime = value; }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentCoroutine = Coroutine_TotalTime();
        StartCoroutine(currentCoroutine);
    }

    #region Total Time Achievement

    private void TotalTime_Check_Achievement()
    {
        if (totalTime <= 300)
        {
            return;
        }
        else if (totalTime <= 420)
        {
            return;
        }
        else if (totalTime <= 640)
        {
            return;
        }
    }

    IEnumerator Coroutine_TotalTime()
    {
        float timer = 0;

        while (!endGame)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        totalTime = timer;
    }
    
    #endregion

    #region Damage Made Achievement

    public void AddDamage_Achievement(int value)
    {
        damageCaused += value;
        DamageCaused_Check_Achievement();
    }
    
    private void DamageCaused_Check_Achievement()
    {
        if (damageCaused >= 600)
        {
            return;
        }
        else if (damageCaused >= 420)
        {
            return;
        }
        else if (damageCaused >= 340)
        {
            return;
        }
    }

    #endregion

    #region Attack 1 Used Times Achievement

    public void AddAttack1_Achievement(int value)
    {
        attack1UsedTimes += value;
        Attack1Used_Check_Achievement();
    }
    
    private void Attack1Used_Check_Achievement()
    {
        if (attack1UsedTimes >= 600)
        {
            return;
        }
        else if (attack1UsedTimes >= 420)
        {
            return;
        }
        else if (attack1UsedTimes >= 340)
        {
            return;
        }
    }

    #endregion
}
