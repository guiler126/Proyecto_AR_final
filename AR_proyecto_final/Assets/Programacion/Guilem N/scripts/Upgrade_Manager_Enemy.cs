using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Manager_Enemy : MonoBehaviour
{
    public StatsInfo statsInfo_speed_ENEMY;
    public StatsInfo statsInfo_DMG_ENEMY;
    public StatsInfo statsInfo_hEALTH_ENEMY;
    
    
    
    private void OnEnable()
    {
        statsInfo_speed_ENEMY.current_lvl = 0;
        statsInfo_DMG_ENEMY.current_lvl = 0;
        statsInfo_hEALTH_ENEMY.current_lvl = 0;
       
    }
    
    private bool CanUpdate(StatsInfo statsInfo)
    {
        if (statsInfo.current_lvl +1 != statsInfo.options_list_lvl.Count )
        {
            return true;
        }

        return false;
    }

    private float ReturnStatValue(StatsInfo statsInfo)
    {
        statsInfo.current_lvl++;
        return statsInfo.options_list_lvl[statsInfo.current_lvl];

      
    }
    
    public void Upgrade_Speed()
    {
        if (CanUpdate(statsInfo_speed_ENEMY))
        {
            enemigo.Instance.navMeshAgent.speed = ReturnStatValue(statsInfo_speed_ENEMY);
        } 
    }


    public void Upgrade_Damage()
    {
        if (CanUpdate(statsInfo_DMG_ENEMY))
        {
            Arma.Instance.damage_enemy = (int) ReturnStatValue(statsInfo_DMG_ENEMY);
        } 
    }
  
  
    public void Upgrade_Health()
    {
        if (CanUpdate(statsInfo_hEALTH_ENEMY))
        {
            BasicEnemy.Instance.health = (int) ReturnStatValue(statsInfo_hEALTH_ENEMY);
        } 
    }
   
  
}
