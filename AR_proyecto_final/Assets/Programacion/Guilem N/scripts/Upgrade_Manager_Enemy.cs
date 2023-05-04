using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Manager_Enemy : MonoBehaviour
{
    public void Upgrade_Speed()
    {
        enemigo.Instance.navMeshAgent.speed += 0.5f;
    }


    public void Upgrade_Damage()
    {
        
    }
  
  
    public void Upgrade_Health()
    {
        BasicEnemy.Instance.health += 100;
    }
   
  
}
