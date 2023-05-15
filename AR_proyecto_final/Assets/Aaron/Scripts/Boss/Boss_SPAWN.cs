using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_SPAWN : MonoBehaviour
{
    [Header("---GO--")]
    public GameObject Boss;
    public GameObject Boss_Panel;
    public GameObject portal;
    public Material Night;

    [SerializeField] private float spawn_timer = 0f;
    [SerializeField] private float time_to_spawn = 4.5f;
    [SerializeField] private float portal_timer = 5f;
    [SerializeField] private float timer_out = 5f;
    public bool Activo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Portal_Boss();
            
        }
        if (Activo == true)
        {
            spawn_timer += Time.deltaTime;
        }
        if (spawn_timer >= time_to_spawn)
        {
            Boss.SetActive(true);
            Boss_Panel.SetActive(true);
            
        }

        if(spawn_timer >= timer_out)
        {
            portal.SetActive(false);
            Activo = false;
            spawn_timer = 0;
        }

    }

    private void Portal_Boss()
    {

        Activo = true;
        portal.SetActive(true);
        RenderSettings.skybox = Night;

    }
}
