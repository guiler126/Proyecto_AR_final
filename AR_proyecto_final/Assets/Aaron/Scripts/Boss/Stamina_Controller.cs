using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Stamina_Controller : MonoBehaviour
{
    [Header("---Emptys---")]
    public GameObject ObjetoACrear;
    public GameObject ObjetoACrear_2;
    public GameObject punto_disparo;


    [Header("Parameters")]
    public float Boss_stamina = 0f;
    [SerializeField] private float max_stamina = 100.0f;
    [SerializeField] private bool Boss_is_Loaded = false;
    [SerializeField] public bool Boss_is_OnFase = false;
    [SerializeField] private Slider stamina_Slider;

    public Animator anim;

    [Header("Stamina_Parameters")]
    [Range(0f, 50f)][SerializeField] private float Stamina_Drain = 20f;
    [Range(0f, 50f)][SerializeField] private float Stamina_Drain_F2 = 18f;
    [Range(0f, 50f)][SerializeField] private float Stamina_Regen = 10f;


    [Header("INFO_ATTACKS_PHASE_2")]
    [SerializeField] private float timeBetweenAttacks_PS_2 = 5f;
    [SerializeField] private float timeLastAttack_PS_2 = 0f;

    [Header("Stamina_UI_Elements")]
    //[SerializeField] private Image stamina_Progress = null;


    public static Stamina_Controller instance;
    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Boss_Controleler.instance.GetComponent<Boss_Controleler>();
        Boss_is_Loaded = false;
    }

    private void Update()
    {
        if (!Boss_is_Loaded && !Boss_is_OnFase)
        {
            Boss_is_Loaded = false;
            Boss_stamina += Stamina_Regen * Time.deltaTime;
            stamina_Slider.value = Boss_stamina;


            if (Boss_stamina >= 100)
            {
                Boss_stamina = 100;
                Boss_is_Loaded = true;
            }

            if (Boss_Controleler.instance.fase == 2)
            {
                timeLastAttack_PS_2 += Time.deltaTime;
                
                if (timeLastAttack_PS_2 >= timeBetweenAttacks_PS_2)
                {
                    anim.SetBool("F2_Attack", true);
                    timeLastAttack_PS_2 = 0;
                }
            }


        } 
        else if(Boss_is_Loaded && Boss_is_OnFase)
        {
            Boss_AI.instance.navMeshAgent.speed = 0;
            Boss_AI.instance.navMeshAgent.isStopped = true;

        } else if (Boss_is_Loaded && !Boss_is_OnFase)
        {
            if (Boss_Controleler.instance.fase == 1)
            {
                LogicaFase_1();
            }
            else if (Boss_Controleler.instance.fase == 2)
            {
                LogicaFase_2();
            }
            else if (Boss_Controleler.instance.fase == 3)
            {
                LogicaFase_3();
            }
        }


    }

    public void FinishAttack_PS_2 ()
    {
        timeLastAttack_PS_2 = 0;
        anim.SetBool("F2_Attack", false);
    }

    public void AcabarBossOnFase()
    {
        Boss_is_OnFase = false;
        anim.SetBool("F2_Walk", true);
        Boss_AI.instance.navMeshAgent.SetDestination(Boss_AI.instance.player.position);
    }



    private void LogicaFase_1()
    {
        anim.SetBool("F1_run", true);
        Boss_AI.instance.navMeshAgent.isStopped = false;
        Boss_AI.instance.navMeshAgent.speed = 10.5f;
        Boss_AI.instance.navMeshAgent.SetDestination(Boss_AI.instance.player.position);
        Boss_stamina -= Stamina_Drain * Time.deltaTime;
        stamina_Slider.value = Boss_stamina;
        Debug.Log("Estoy llegando");


        if (Boss_stamina <= 0)
        {
            anim.SetBool("F1_run", false);
            Boss_AI.instance.navMeshAgent.speed = 3.5f;
            Boss_is_Loaded = false;
        }
    }


    private void LogicaFase_2()
    {
 
        anim.SetBool("F2_Load_Attack", true);
        Boss_AI.instance.navMeshAgent.speed = 0;
        Boss_stamina -= Stamina_Drain_F2 * Time.deltaTime;
        stamina_Slider.value = Boss_stamina;


        if (Boss_stamina <= 0)
        {
            anim.SetBool("F2_Load_Attack", false);
            Boss_AI.instance.navMeshAgent.speed = 3f;
            Boss_is_Loaded = false;
        }

    }

    /**IEnumerator Ataque_normal()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("F2_Attack", true);
        Instantiate(ObjetoACrear_2, punto_disparo.transform.position, punto_disparo.transform.rotation);
    }*/


    private void LogicaFase_3()
    {
        //
    }

    public void Proyectil_1()
    {
        Instantiate(ObjetoACrear_2, punto_disparo.transform.position, punto_disparo.transform.rotation);
    }

    public void Proyectil_Followable()
    {
        Instantiate(ObjetoACrear_2, punto_disparo.transform.position, punto_disparo.transform.rotation);
    }
}
