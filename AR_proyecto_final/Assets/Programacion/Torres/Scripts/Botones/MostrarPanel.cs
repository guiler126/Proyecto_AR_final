using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPanel : MonoBehaviour
{


    public GameObject panel;



    public void Mostrarpanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }










}
