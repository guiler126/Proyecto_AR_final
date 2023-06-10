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
    private int totalTime;
    
    [Header("----- Sounds List -----")]
    [SerializeField] private List<Logro_Data> logroData_list;
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
    
    public int TotalTime
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

    public void StartTimeCheck()
    {
        currentCoroutine = Coroutine_TotalTime();
        StartCoroutine(currentCoroutine);
    }

    public void Refresh_Logro_List()
    {
        Clean_Sound_List();

        foreach (Logro_Data logro in logroData_list)
        {
            Item_logros_list _item_logros_list;
                _item_logros_list = Instantiate(item_logros_list, content_logros_list.transform);
                _item_logros_list.title = logro.title;
                _item_logros_list.sprite.sprite = logro.icon;
                _item_logros_list.textTotal_1.text = $"{logro.numberTotal_1}";
                _item_logros_list.textTotal_2.text = $"{logro.numberTotal_2}";
                _item_logros_list.textTotal_3.text = $"{logro.numberTotal_3}";
                _item_logros_list.logro_1.maxValue = logro.numberTotal_1;
                _item_logros_list.logro_2.maxValue = logro.numberTotal_2;
                _item_logros_list.logro_3.maxValue = logro.numberTotal_3;
                _item_logros_list.logro_1.value = logro.numberVariable;
                _item_logros_list.logro_2.value = logro.numberVariable;
                _item_logros_list.logro_3.value = logro.numberVariable;
        }
    }    
    
    private void Clean_Sound_List()
    {
        foreach (Transform child in content_logros_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void ValuesLogro(string title, int numCheck)
    {
        foreach (var logro in logroData_list)
        {
            if (logro.name == title)
            {
                logro.numberVariable = numCheck;
            }
        }
    }

    #region Total Time Achievement

    private void TotalTime_Check_Achievement()
    {
        ValuesLogro("Time", totalTime);
    }

    IEnumerator Coroutine_TotalTime()
    {
        float timer = 0;

        while (!endGame)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        totalTime = ((int)timer);
    }
    
    #endregion

    #region Damage Made Achievement

    public void AddDamage_Achievement(int value)
    {
        damageCaused += value;
        ValuesLogro("Damage", damageCaused);
    }

    #endregion

    #region Attack 1 Used Times Achievement

    public void AddAttack1_Achievement()
    {
        ++attack1UsedTimes;

        ValuesLogro("Attack 1", attack1UsedTimes);
    }

    
    #endregion    
    
    #region Attack 2 Used Times Achievement

    public void AddAttack2_Achievement()
    {
        ++attack2UsedTimes;
        ValuesLogro("Attack 2", attack2UsedTimes);
    }

    #endregion
    
    #region Dash Used Times Achievement

    public void AddADash_Achievement()
    {
        ++dashUsedTimes;
        ValuesLogro("Dash", dashUsedTimes);
    }

    #endregion
}
