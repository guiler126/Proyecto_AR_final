using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina_Controller : MonoBehaviour
{

    [Header("Parameters")]
    public float Boss_stamina = 0f;
    [SerializeField] private float max_stamina = 100.0f;
    [SerializeField] private bool Boss_is_attacking = false;
    [SerializeField] private Slider stamina_Slider;



    [Header("Stamina_Parameters")]
    [Range(0f, 50f)][SerializeField] private float Stamina_Drain = 20f;
    [Range(0f, 50f)][SerializeField] private float Stamina_Regen = 0.5f;

    [Header("Stamina_UI_Elements")]
    //[SerializeField] private Image stamina_Progress = null;

    public static Stamina_Controller instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Boss_Controleler.instance.GetComponent<Boss_Controleler>();
        Boss_is_attacking = false;
    }

    private void Update()
    {
        if (!Boss_is_attacking)
        {
            Boss_is_attacking = false;
            Boss_stamina += Stamina_Regen * Time.deltaTime;
            stamina_Slider.value = Boss_stamina;
            
        }
        if(!Boss_is_attacking && Boss_stamina == 100) 
        
        {
            Boss_Full_Stamina();

        }

    }

    public void Boss_Full_Stamina()
    {
        Boss_is_attacking = true;
        Boss_stamina -= Stamina_Drain * Time.deltaTime;
        stamina_Slider.value = Boss_stamina;

    }

}
