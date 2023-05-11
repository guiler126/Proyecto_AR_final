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
      statsInfo_DashSpeed.current_lvl = 0;
      statsInfo_Mana.current_lvl = 0;
      statsInfo_Mana_Regeneration.current_lvl = 0;
      statsInfo_BulletDamage.current_lvl = 0;
      statsInfo_HabilityDamage.current_lvl = 0;
      statsInfo_Health.current_lvl = 0;
      statsInfo_HabilityCooldown.current_lvl = 0;
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
      if (CanUpdate(statsInfo_speed))
      {
         PlayerController.instance.speed = ReturnStatValue(statsInfo_speed);
      }
   }

   
   
   public void Upgrade_Dash_Speed()
   {
      if (CanUpdate(statsInfo_DashSpeed))
      {
         PlayerController.instance.dashSpeed = ReturnStatValue(statsInfo_DashSpeed);
      }
   }
   public void Upgrade_Mana()
   {
      if (CanUpdate(statsInfo_Mana))
      {
         Mana_Controller.instance.Slider_Mana.maxValue = ReturnStatValue(statsInfo_Mana);
      }
      
   }
   public void Upgrade_Mana_Regeneration()
   {
      if (CanUpdate(statsInfo_Mana_Regeneration))
      {
         Mana_Controller.instance.recoveryVelocity = ReturnStatValue(statsInfo_Mana_Regeneration);
      }
      
   }
   public void Upgrade_Damage_Basics()
   {
      if (CanUpdate(statsInfo_BulletDamage))
      {
         Bullet_Basic.instance.damage = (int) ReturnStatValue(statsInfo_BulletDamage);
      }
   }
   public void Upgrade_Damage_Hability()
   {
      if (CanUpdate(statsInfo_HabilityDamage))
      {
         Bullet_Hability.instance.damage_hability = (int) ReturnStatValue(statsInfo_HabilityDamage);
      }
      
   }
   public void Upgrade_Health()
   {
      if (CanUpdate(statsInfo_Health))
      {
         PlayerController.instance.health = ReturnStatValue(statsInfo_Health);
      }
   }
   
   public void Upgrade_Cooldown_Hability()
   {
      if (CanUpdate(statsInfo_HabilityCooldown))
      {
         PlayerController.instance.timeBetweenSecondaryAttack = ReturnStatValue(statsInfo_HabilityCooldown);
      }
      
   }
}
