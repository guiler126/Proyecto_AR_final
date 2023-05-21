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

    private void Start()
    {
        currentCoroutine = Coroutine_TotalTime();
        StartCoroutine(currentCoroutine);
        Refresh_Sound_List();
    }

    public void Refresh_Sound_List()
    {
        Clean_Sound_List();

        foreach (Logro_Data logro in logroData_list)
        {
            if (logro.IsCompleted)
            {
                Item_logros_list _item_logros_list;
                _item_logros_list = Instantiate(item_logros_list, content_logros_list.transform);
                _item_logros_list.sprite = logro.Sprite;
                _item_logros_list.numVar = logro.NumberVariable;
                
                if (Application.systemLanguage == SystemLanguage.Spanish)
                {
                    _item_logros_list.title = logro.Title_Es; 
                    _item_logros_list.description = logro.Description_Es; 
                }
                else if (Application.systemLanguage == SystemLanguage.Catalan)
                {
                    _item_logros_list.title = logro.Title_Ca; 
                    _item_logros_list.description = logro.Description_Ca; 
                }
                else if (Application.systemLanguage == SystemLanguage.English)
                {
                    _item_logros_list.title = logro.Title_En; 
                    _item_logros_list.description = logro.Description_En; 
                }
                else if (Application.systemLanguage == SystemLanguage.French)
                {
                    _item_logros_list.title = logro.Title_Fr; 
                    _item_logros_list.description = logro.Description_Fr; 
                }
            }
        }
    }    
    
    private void Clean_Sound_List()
    {
        foreach (Transform child in content_logros_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void MarkCompletedLogro(string title, int numCheck)
    {
        foreach (var logro in logroData_list)
        {
            if (logro.Title_En == title)
            {
                if (logro.NumberVariable >= numCheck && !logro.IsCompleted)
                {
                    logro.IsCompleted = true;
                }
            }
        }
    }

    #region Total Time Achievement

    private void TotalTime_Check_Achievement()
    {
        MarkCompletedLogro("Total Time", totalTime);
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
        MarkCompletedLogro("Damage Caused", damageCaused);
    }

    #endregion

    #region Attack 1 Used Times Achievement

    public void AddAttack1_Achievement()
    {
        ++attack1UsedTimes;

        MarkCompletedLogro("Attack 1 Used Times", attack1UsedTimes);
    }

    
    #endregion    
    
    #region Attack 2 Used Times Achievement

    public void AddAttack2_Achievement()
    {
        ++attack2UsedTimes;
        MarkCompletedLogro("Attack 2 Used Times", attack2UsedTimes);
    }

    #endregion
    
    #region Dash Used Times Achievement

    public void AddADash_Achievement()
    {
        ++dashUsedTimes;
        MarkCompletedLogro("Dash Used Times", dashUsedTimes);
    }

    #endregion
}
