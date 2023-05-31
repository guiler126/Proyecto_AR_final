using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Stamina_Controller : MonoBehaviour
{
    [Header("---FILLABLE GO---")]
    public GameObject punto_disparo;
    public GameObject Invoked_Enemy;
    public GameObject Invoke_Point;
    public GameObject VFX_Slash;
    public GameObject VFX_Slash_charged;


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
    [Range(0f, 50f)][SerializeField] private float Stamina_Drain_F3 = 30f;
    [Range(0f, 50f)][SerializeField] private float Stamina_Regen = 10f;


    [Header("INFO_ATTACKS_PHASE_2")]
    [SerializeField] private float timeBetweenAttacks_PS_2 = 5f;
    [SerializeField] private float timeLastAttack_PS_2 = 0f;


    [Header("INFO_ACTIONS_PHASE_3")]
    [SerializeField] private float timeBetweenAttacks_PS_3 = 4f;
    [SerializeField] private float timeLastAttack_PS_3 = 0f;
    [SerializeField] private float time_Between_Invokes_PS_3 = 7f;
    [SerializeField] private float time_Last_Invoke_PS_3 = 0f;

    [Header("Stamina_UI_Elements")]
    //[SerializeField] private Image stamina_Progress = null;
    
    [Space]
    [Header("---- Object Pooling ----")]
    // Canviar per nom bullet que toqui
    public PoolingItemsEnum enemy;
    public PoolingItemsEnum slash_op;
    public PoolingItemsEnum slash_loaded_op;


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

            if (Boss_Controleler.instance.fase == 3)
            {
                timeLastAttack_PS_3 += Time.deltaTime;

                if (timeLastAttack_PS_3 >= timeBetweenAttacks_PS_3)
                {
                    anim.SetBool("F3_Attack", true);
                    timeLastAttack_PS_3 = 0;
                }

                //invocar cada 10 segundos
            }

            if(Boss_Controleler.instance.fase == 3)
            {
                time_Last_Invoke_PS_3 += Time.deltaTime;
                if(time_Last_Invoke_PS_3 >= time_Between_Invokes_PS_3)
                {
                    anim.SetBool("F3_Invoke", true);
                    time_Last_Invoke_PS_3 = 0;
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

    public void FinishAttack_PS_3()
    {
        timeLastAttack_PS_2 = 0;
        anim.SetBool("F3_Attack", false);
    }

    public void Finish_Invoke_PS_3()
    {
        timeLastAttack_PS_2 = 0;
        anim.SetBool("F3_Invoke", false);
    }

    public void AcabarBossOnFase()
    {
        Boss_is_OnFase = false;
        anim.SetBool("F2_Walk", true);
        Boss_AI.instance.navMeshAgent.SetDestination(Boss_AI.instance.player.position);
    }

    public void Acabar_Boss_F3()
    {
        Boss_is_OnFase = false;
        anim.SetBool("F3_Walk", true);
        Boss_AI.instance.navMeshAgent.speed = 5;
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

    private void LogicaFase_3()
    {
        anim.SetBool("F3_Heal", true);
        Boss_AI.instance.navMeshAgent.speed = 0;
        Boss_stamina -= Stamina_Drain_F3 * Time.deltaTime;
        stamina_Slider.value = Boss_stamina;

        if (Boss_stamina <= 0)
        {
            anim.SetBool("F3_Heal", false);
            anim.SetBool("F3_Walk", true);
            Boss_AI.instance.navMeshAgent.speed = 5f;
            Boss_is_Loaded = false;
        }
    }

    /**public void Proyectil_Loaded()
    {
        Instantiate(Proyectil_Cargado, punto_disparo.transform.position, punto_disparo.transform.rotation);
    }*/


    public void Slash_Projectile()
    {
        //Instantiate(VFX_Slash, punto_disparo.transform.position, transform.rotation);
        GameObject slash = PoolingManager.Instance.GetPooledObject((int)slash_op);
        slash.transform.position = punto_disparo.transform.position;
        slash.transform.rotation = transform.rotation;
        slash.SetActive(true);
    }

    public void Charged_Projectile()
    {
        //Instantiate(VFX_Slash_charged, punto_disparo.transform.position, transform.rotation);
        GameObject slash_charged = PoolingManager.Instance.GetPooledObject((int)slash_loaded_op);
        slash_charged.transform.position = punto_disparo.transform.position;
        slash_charged.transform.rotation = transform.rotation;
        slash_charged.SetActive(true);
    }


    //VOIDS CURAR E INVOCAR FASE 3
    public void Curar_Vida()
    {
        Boss_Controleler.instance.HP += 12;
        Boss_Controleler.instance.Health_bar.value = Boss_Controleler.instance.HP;
    }

    public void Invoke_Enemy()
    {
        //Instantiate(Invoked_Enemy, Invoke_Point.transform.position, Invoke_Point.transform.rotation);
        GameObject enemy = PoolingManager.Instance.GetPooledObject((int)this.enemy);
        enemy.transform.position = Invoke_Point.transform.position;
        enemy.transform.rotation = Invoke_Point.transform.rotation;
        enemy.SetActive(true);
    }
}
