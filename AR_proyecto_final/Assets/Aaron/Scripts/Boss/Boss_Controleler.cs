using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
            Switch();
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 3f)
        {
            //animator.transform.LookAt(player);
            animator.SetBool("Attack", true);
            //Player_Main.instance.HP -= Boss_Damage;
            //Player_Main.instance.Health_bar.value = Player_Main.instance.HP;
            Debug.Log("Estoy atacando");
        }
            
        if(distance >= 3)
        {
            animator.SetBool("Attack", false);
            Debug.Log("Te estas alejando");
        }
    }

    private void Switch()
    {
        switch (HP)
        {

            case 30:
                {
                    //fase 3
                    animator.SetTrigger("New_Stage");
                    //bloquear movimiento
                    Debug.Log("30");
                    break;
                }

            case 60:
                {
                    //fase 2
                    animator.SetTrigger("New_Stage");
                    //bloquear movimiento
                    Fase2();
                    break;

                }

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
            
        }
        else
        {
            //FindObjectOfType<AudioManager>().PlaySound("DragonHit");
            //animator.SetTrigger("Damage");
        }
    }

    public void PlayerDamage(int damageAmount)
    {
        Player_Main.instance.HP -= damageAmount;
        Player_Main.instance.Health_bar.value = Player_Main.instance.HP;
        if (Player_Main.instance.HP <= 0)
        {
            Debug.Log("Estoy muerto");

        }
    }

    private void Fase2()
    {
        Debug.Log("Estoy en fase 2");
    }
}
