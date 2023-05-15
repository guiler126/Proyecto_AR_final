using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcultarPanel : MonoBehaviour
{
     public GameObject OCULTARpanel;


    public void Ocultar()
    {
        if(OCULTARpanel.activeSelf == true)
        {
            OCULTARpanel.SetActive(false);
        }
        
    }









}
