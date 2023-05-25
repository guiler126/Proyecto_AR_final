using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Manager_Enemy : MonoBehaviour
{
    public static Upgrade_Manager_Enemy instace;

    public StatsInfo statsInfo_speed_ENEMY;
    public StatsInfo statsInfo_DMG_ENEMY;
    public StatsInfo statsInfo_hEALTH_ENEMY;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        statsInfo_speed_ENEMY.current_lvl = 0;
        statsInfo_speed_ENEMY.maxLvl = false;
        statsInfo_DMG_ENEMY.current_lvl = 0;
        statsInfo_DMG_ENEMY.maxLvl = false;
        statsInfo_hEALTH_ENEMY.current_lvl = 0;
        statsInfo_hEALTH_ENEMY.maxLvl = false;
    }
    
    public void RefreshAllStats()
    {
        Upgrade_Health();
        Upgrade_Damage();
        Upgrade_Speed();
    }
    
    private bool CanUpdate(StatsInfo statsInfo)
    {
        if (statsInfo.current_lvl +1 != statsInfo.options_list_lvl.Count )
        {
            return true;
        }
        else
        {
            statsInfo.maxLvl = true;
        }

        return false;
    }

    private float ReturnStatValue(StatsInfo statsInfo)
    { 
        return statsInfo.options_list_lvl[statsInfo.current_lvl];
    }
    
    public void Upgrade_Speed()
    {
        if (CanUpdate(statsInfo_speed_ENEMY))
        {
            ReturnStatValue(statsInfo_speed_ENEMY);
        } 
    }


    public void Upgrade_Damage()
    {
        if (CanUpdate(statsInfo_DMG_ENEMY))
        {
            ReturnStatValue(statsInfo_DMG_ENEMY);
        } 
    }
  
  
    public void Upgrade_Health()
    {
        if (CanUpdate(statsInfo_hEALTH_ENEMY))
        {
            ReturnStatValue(statsInfo_hEALTH_ENEMY);
        } 
    }
   
  
}
