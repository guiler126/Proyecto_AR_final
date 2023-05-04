using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade_Manager_Player : MonoBehaviour
{

   public StatsInfo statsInfo_speed;
   public StatsInfo statsInfo_DashSpeed;
   public StatsInfo statsInfo_Mana;
   public StatsInfo statsInfo_Mana_Regeneration;
   public StatsInfo statsInfo_BulletDamage;
   public StatsInfo statsInfo_HabilityDamage;
   public StatsInfo statsInfo_Health;
   public StatsInfo statsInfo_HabilityCooldown;

   
   private void OnEnable()
   {
      statsInfo_speed.current_lvl = 0;
   }
   
   private bool CanUpdate(StatsInfo statsInfo)
   {
      if (statsInfo.current_lvl +1 != statsInfo.options_list_lvl.Count )
      {
         return true;
      }

      return false;
   }

   private void UpdateStat(StatsInfo statsInfo, float statPlayerToUpdate)
   {
      statsInfo.current_lvl++;
      statPlayerToUpdate = statsInfo.options_list_lvl[statsInfo.current_lvl];

      
   }

   public void Upgrade_Speed()
   {
      if (CanUpdate(statsInfo_speed))
      {
         UpdateStat(statsInfo_speed, PlayerController.instance.speed);
      }
   }

   
   
   public void Upgrade_Dash_Speed()
   {
      if (CanUpdate(statsInfo_DashSpeed))
      {
         UpdateStat(statsInfo_DashSpeed, PlayerController.instance.dashSpeed);
      }
   }
   public void Upgrade_Mana()
   {
      if (CanUpdate(statsInfo_Mana))
      {
         UpdateStat(statsInfo_Mana,  Mana_Controller.instance.Slider_Mana.maxValue);
      }
      
   }
   public void Upgrade_Mana_Regeneration()
   {
      if (CanUpdate(statsInfo_Mana_Regeneration))
      {
         UpdateStat(statsInfo_Mana_Regeneration,   Mana_Controller.instance.recoveryVelocity);
      }
      
   }
   public void Upgrade_Damage_Basics()
   {
      if (CanUpdate(statsInfo_BulletDamage))
      {
         UpdateStat(statsInfo_BulletDamage,    Bullet_Basic.instance.damage);
      }
   }
   public void Upgrade_Damage_Hability()
   {
      if (CanUpdate(statsInfo_HabilityDamage))
      {
         UpdateStat(statsInfo_HabilityDamage,     Bullet_Hability.instance.damage_hability);
      }
      
   }
   public void Upgrade_Health()
   {
      if (CanUpdate(statsInfo_Health))
      {
         UpdateStat(statsInfo_Health,      PlayerController.instance.health);
      }
   }
   
   public void Upgrade_Cooldown_Hability()
   {
      if (CanUpdate(statsInfo_HabilityCooldown))
      {
         UpdateStat(statsInfo_HabilityCooldown,      PlayerController.instance.timeBetweenSecondaryAttack);
      }
      
   }
}
