using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public GameObject health_1;
    public GameObject health_2;
    public GameObject health_3;
    public GameObject health_4;
    public GameObject health_5;


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
}
