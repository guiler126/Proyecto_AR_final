using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Controller : MonoBehaviour
{
    public Slider Slider_Mana;

    public static Mana_Controller instance;

    public float recoveryVelocity;

    private void Awake()
    {
        instance = this;
        
        Slider_Mana.value = 200f;
    }

    private void Update()
    {
        RelaodMana();
    }


    public void RelaodMana()
    {
        if (Slider_Mana.value < 200f && PlayerController.instance.imAttacking == false)
        {
            Slider_Mana.value += recoveryVelocity;
        }
    }

   
}
