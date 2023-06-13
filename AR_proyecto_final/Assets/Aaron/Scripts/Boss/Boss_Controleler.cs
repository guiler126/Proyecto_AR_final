using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Controleler : MonoBehaviour
{
    [Header("---Parameters---")]
    public int HP = 100;
    public int MAX_HP = 100;
    [Tooltip("Da�o del player hacia el boss")]
    public int DamageAmount = 10;
    [Tooltip("Da�o del Boss hacia el player")]
    public int Boss_Damage;

    public int percentage_fase_2 = 60;
    public int percentage_fase_3 = 30;

    [Header("---Others---")]
    public Transform player;
    public Animator animator;
    public GameObject sword;


    [Header("---Sliders/Bars---")]
    public Slider Health_bar;
    public Slider stamina_bar;

    [Header("--- Escala F3 ---")]
    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float Scale_speed = 2f;
    public float duration = 10f;

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
            //TakeDamage();
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 3f)
        {
            animator.transform.LookAt(player);
            animator.SetBool("Attack", true);
            Ui_Manager.instance.slider_health.value = PlayerController.instance.health;
        }
            
        if(distance >= 3)
        {
            animator.SetBool("Attack", false);
        }
    }

    //DA�O RECIBIDO AL BOSS Y SU CAMBIO DE FASE CON ANIM EN BASE A SU HP
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Health_bar.value = HP;


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
            Boss_AI.instance.navMeshAgent.speed = 0;
            Stamina_Controller.instance.Boss_is_OnFase = true;
            animator.SetTrigger("F3_Stage");
            fase = 3;
        }

    }

    //DA�AR AL MAIN PLAYER (A TI)
    public void PlayerDamage()
    {
        //PlayerController.instance.TakeDamage(Boss_Damage);
        Debug.Log("Soy tu padree");

        PlayerController.instance.Boss_Damage();
    }

    public void _No_Life()
    {
        PlayerController.instance._boss_at = false;
    }



    //ESCALAR AL BOSS EN FASE 3
    public IEnumerator ScaleLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Scale_speed;
        while (i < 1.0f) 
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
    public void Start_Scaling()
    {
        minScale = transform.localScale;
        StartCoroutine(ScaleLerp(minScale, maxScale, duration));
    }

    public void Finish_Scaling()
    {
        StopCoroutine(ScaleLerp(minScale, maxScale, duration));
    }


    public void Cambio_Fase2()
    {
        Stamina_Controller.instance.Boss_is_OnFase = true;
        animator.SetTrigger("f2_1");
    }

    public void Activar_Espada()
    {
        sword.SetActive(true);
    }

}
