using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    public GameObject panelPausa;



    public void BotonPausa()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0;
    }


    public void BotonPlay()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1;
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BotonPausa();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            BotonPlay();
        }

    }








}
