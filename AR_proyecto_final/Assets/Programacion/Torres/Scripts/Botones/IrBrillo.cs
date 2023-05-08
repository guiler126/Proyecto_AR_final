using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IrBrillo : MonoBehaviour
{


    public GameObject brillo;
    public GameObject PanelOCULTAR;


    private void Start()
    {
        brillo.SetActive(false);
    }


    public void PanelOpciones()
    {
        if (brillo != false)
        {
            bool EstaActivo = brillo.activeSelf;

            brillo.SetActive(!EstaActivo);
        }
        
    }



}
