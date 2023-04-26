using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Controleler : MonoBehaviour
{
    [Header("---Parameters---")]
    public int HP = 100;
    [Tooltip("Daño del player hacia el boss")]
    public int DamageAmount = 10;
    [Tooltip("Daño del Boss hacia el player")]
    public int Boss_Damage = 10;

    [Header("---Others---")]
    public Transform player;
    public Animator animator;
    

    [Header("---Sliders/Bars---")]
    public Slider Health_bar;
    public Slider stamina_bar;

    public static Boss_Controleler instance;

    private void Awake()
    {
        instance = this;
    }

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
        
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 3f)
        {
            //animator.transform.LookAt(player);
            animator.SetBool("Attack", true);
            Player_Main.instance.HP -= Boss_Damage;
            Player_Main.instance.Health_bar.value = Player_Main.instance.HP;
            Debug.Log("Estoy atacando");
        }
            
        if(distance >= 3)
        {
            animator.SetBool("Attack", false);
            Debug.Log("Te estas alejando");
        }
    }

    public void TakeDamage()
    {
        HP -= DamageAmount;
        Health_bar.value = HP;
        Debug.Log("Estoy aqui");

        if (HP <= 0)
        {

            //FindObjectOfType<AudioManager>().PlaySound("DragonDeath");
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            //SceneManager.LoadScene(3);
        }
        else
        {
            //FindObjectOfType<AudioManager>().PlaySound("DragonHit");
            //animator.SetTrigger("Damage");
        }
    }


}
