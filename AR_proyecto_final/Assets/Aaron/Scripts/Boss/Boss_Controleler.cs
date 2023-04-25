using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Controleler : MonoBehaviour
{
    public int HP = 100;
    public Transform player;
    public Animator animator;
    //public Slider healthbar;
    
    //---DAÑO DEL PLAYER---
    public int DamageAmount = 10;

    private void Update()
    {
        //healthbar.value = HP;
        /*if(HP < 60)
        {
            //FASE 2
        }
        else
        {
            //ATACAR
        }
        if (HP < 30)
        {
            //FASE 3
        }
        else
        {
            //FASE 2
        }*/

        switch (HP) 
        { 
            case 0:
                {
                    //morir
                    break;
                }

            case 30: 
                {
                    //fase 3
                    break;
                }

            case 60: 
                {
                    //fase 2
                    break;
                
                }

            case 100:
                {
                    //normal
                    break;
                }
        
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();

        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 5f)
        {
            animator.transform.LookAt(player);
            Debug.Log("Estoy atacando");
            //animator.SetBool("IsAttacking", false);
        }
            
        else
        {
            Debug.Log("Te estas alejando");
        }
    }

    public void TakeDamage()
    {
        HP -= DamageAmount;
        if (HP <= 0)
        {
            //FindObjectOfType<AudioManager>().PlaySound("DragonDeath");
            //animator.SetTrigger("Die");
            //GetComponent<Collider>().enabled = false;
            //SceneManager.LoadScene(3);
        }
        else
        {
            //FindObjectOfType<AudioManager>().PlaySound("DragonHit");
            //animator.SetTrigger("Damage");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //atacar
        }
    }


}
