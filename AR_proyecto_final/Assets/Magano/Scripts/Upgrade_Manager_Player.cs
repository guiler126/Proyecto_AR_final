using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Manager_Player : MonoBehaviour
{
   public void Upgrade_Speed()
   {
      PlayerController.instance.speed += 1f;
   }
   public void Upgrade_Dash_Speed()
   {
      PlayerController.instance.dashSpeed += 5f;
   }
   public void Upgrade_Mana()
   {
      Mana_Controller.instance.Slider_Mana.maxValue += 50f;
   }
   public void Upgrade_Mana_Regeneration()
   {
      Mana_Controller.instance.recoveryVelocity += 0.01f;
   }
   public void Upgrade_Damage_Basics()
   {
      //por hacer 
   }
   public void Upgrade_Damage_Hability()
   {
      //por hacer  
   }
   public void Upgrade_Health()
   {
      PlayerController.instance.health += 1;
   }
   
   public void Upgrade_Cooldown_Hability()
   {
      PlayerController.instance.timeBetweenSecondaryAttack -= 0.5f;
   }
}
