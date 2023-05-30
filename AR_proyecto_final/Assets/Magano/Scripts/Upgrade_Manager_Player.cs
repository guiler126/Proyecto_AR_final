using System;
using UnityEngine;

public class Upgrade_Manager_Player : MonoBehaviour
{

   public static Upgrade_Manager_Player instace;

   public StatsInfo statsInfo_speed;
   public StatsInfo statsInfo_DashSpeed;
   public StatsInfo statsInfo_Mana;
   public StatsInfo statsInfo_Mana_Regeneration;
   public StatsInfo statsInfo_BulletDamage;
   public StatsInfo statsInfo_HabilityDamage;
   public StatsInfo statsInfo_Health;
   public StatsInfo statsInfo_HabilityCooldown;

   public Bullet_Hability[] bullets;

   
   private void OnEnable()
   {
      statsInfo_speed.current_lvl = 0;
      statsInfo_speed.maxLvl = false;
      statsInfo_DashSpeed.current_lvl = 0;
      statsInfo_DashSpeed.maxLvl = false;
      statsInfo_Mana.current_lvl = 0;
      statsInfo_Mana.maxLvl = false;
      statsInfo_Mana_Regeneration.current_lvl = 0;
      statsInfo_Mana_Regeneration.maxLvl = false;
      statsInfo_BulletDamage.current_lvl = 0;
      statsInfo_BulletDamage.maxLvl = false;
      statsInfo_HabilityDamage.current_lvl = 0;
      statsInfo_HabilityDamage.maxLvl = false;
      statsInfo_Health.current_lvl = 0;
      statsInfo_Health.maxLvl = false;
      statsInfo_HabilityCooldown.current_lvl = 0;
      statsInfo_HabilityCooldown.maxLvl = false;
   }


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

   public void RefreshAllStats()
   {
      Upgrade_Health();
      Upgrade_Mana();
      Upgrade_Speed();
      Upgrade_Cooldown_Hability();
      Upgrade_Damage_Basics();
      Upgrade_Damage_Hability();
      Upgrade_Dash_Speed();
      Upgrade_Mana_Regeneration();
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
      if (CanUpdate(statsInfo_speed) && GameManager.instance.PointStats > 0)
      {
         PlayerController.instance.speed = ReturnStatValue(statsInfo_speed);
      }
   }

   public void Upgrade_Dash_Speed()
   {
      if (CanUpdate(statsInfo_DashSpeed) && GameManager.instance.PointStats > 0)
      {
         PlayerController.instance.dashSpeed = ReturnStatValue(statsInfo_DashSpeed);
      }
   }
   
   public void Upgrade_Mana()
   {
      if (CanUpdate(statsInfo_Mana) && GameManager.instance.PointStats > 0)
      {
         Mana_Controller.instance.Slider_Mana.maxValue = ReturnStatValue(statsInfo_Mana);
      }
      
   }
   
   public void Upgrade_Mana_Regeneration()
   {
      if (CanUpdate(statsInfo_Mana_Regeneration) && GameManager.instance.PointStats > 0)
      {
         Mana_Controller.instance.recoveryVelocity = ReturnStatValue(statsInfo_Mana_Regeneration);
      }
      
   }
   
   public void Upgrade_Damage_Basics()
   {
      if (CanUpdate(statsInfo_BulletDamage) && GameManager.instance.PointStats > 0)
      {
         Bullet_Basic.instance.damage = (int) ReturnStatValue(statsInfo_BulletDamage);
      }
   }
   
   public void Upgrade_Damage_Hability()
   {
      if (CanUpdate(statsInfo_HabilityDamage) && GameManager.instance.PointStats > 0)
      {
         foreach (var value in bullets)
         {
            value.damage_hability = (int) ReturnStatValue(statsInfo_HabilityDamage);
         }
      }
   }
   
   public void Upgrade_Health()
   {
      if (CanUpdate(statsInfo_Health) && GameManager.instance.PointStats > 0)
      {
         PlayerController.instance.health = ReturnStatValue(statsInfo_Health);
         Ui_Manager.instance.slider_health.value = PlayerController.instance.health;
      }
   }
   
   public void Upgrade_Cooldown_Hability()
   {
      if (CanUpdate(statsInfo_HabilityCooldown) && GameManager.instance.PointStats > 0)
      {
         PlayerController.instance.timeBetweenSecondaryAttack = ReturnStatValue(statsInfo_HabilityCooldown);
      }
      
   }
}
