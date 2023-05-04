using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss_Controleler : MonoBehaviour
{
    [Header("---Parameters---")]
    public int HP = 100;
    public int MAX_HP = 100;
    [Tooltip("Daño del player hacia el boss")]
    public int DamageAmount = 10;
    [Tooltip("Daño del Boss hacia el player")]
    public int Boss_Damage = 10;

    public int percentage_fase_2 = 60;
    public int percentage_fase_3 = 30;

    [Header("---Others---")]
    public Transform player;
    public Animator animator;
    public GameObject sword;


    [Header("---Sliders/Bars---")]
    public Slider Health_bar;
    public Slider stamina_bar;

    public int fase;

    public static Boss_Controleler instance;

    private void Awake()
    {
        instance = this;
        fase = 1;
        HP = MAX_HP;
    }

    private void Start()
    {
        sword.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
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


    public void TakeDamage()
    {
        HP -= DamageAmount;
        Health_bar.value = HP;
        Debug.Log("Estoy aqui");


        if (HP <= 0)
        {

            //FindObjectOfType<AudioManager>().PlaySound("DragonDeath");
            animator.SetTrigger("Die");
            //GetComponent<Collider>().enabled = false;
            
        }

        if (HP < (MAX_HP * percentage_fase_2 / 100) && HP > (MAX_HP * percentage_fase_3 / 100))
        {
            Boss_AI.instance.navMeshAgent.speed = 0;
            Stamina_Controller.instance.Boss_is_OnFase = true;
            animator.SetTrigger("New_Stage");
            fase = 2;
        } else if (HP < (MAX_HP * percentage_fase_3 / 100))
        {
            fase = 3;
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


    public void Cambio_Fase2()
    {
        //Stamina_Controller.instance.Boss_is_OnFase = true;
        animator.SetTrigger("f2_1");
    }

    public void Activar_Espada()
    {
        sword.SetActive(true);
    }

}
