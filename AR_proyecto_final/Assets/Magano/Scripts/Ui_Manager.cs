using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager instance;
    
    public GameObject health_1;
    public GameObject health_2;
    public GameObject health_3;
    public GameObject health_4;
    public GameObject health_5;

    [SerializeField] private GameObject win_Panel;
    [SerializeField] private GameObject lose_Panel;
    [SerializeField] private TMP_Text pointStats_txt;

    public PoolingItemsEnum enemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Update_Health();
    }

    public void Update_Health()
    {
        if (PlayerController.instance.health == 4)
        {
            health_5.SetActive(false);
        }

        if (PlayerController.instance.health == 3)
        {
            health_4.SetActive(false);
        }
        if (PlayerController.instance.health == 2)
        {
            health_3.SetActive(false);
        }
        if (PlayerController.instance.health == 1)
        {
            health_2.SetActive(false);
        }
        if (PlayerController.instance.health <= 0)
        {
            health_1.SetActive(false);
        }
    }

    public void WinCondition()
    {
        pointStats_txt.text = $"{GameManager.instance.PointStats}";
        win_Panel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void LoseCondition()
    {
        lose_Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextRound()
    {
        Time.timeScale = 1;
        win_Panel.SetActive(false);
        PoolingManager.Instance.DesactivatePooledObject((int)enemy);
        Sistema_Oleadas.Instance.Checker();
        Sistema_Missions.instance.StartMissionRound();
    }
}
