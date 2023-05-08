using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrOpciones : MonoBehaviour
{

    public GameObject Opciones;
    public GameObject PanelOCULTAR;


    private void Start()
    {
        Opciones.SetActive(false);
    }


    public void PanelOpciones()
    {
        if(Opciones != false)
        {
            bool EstaActivo = Opciones.activeSelf;

            Opciones.SetActive(!EstaActivo);
        }
       
    }

    public void Desaparecer()
    {
        if(PanelOCULTAR != true)
        {
          PanelOCULTAR.SetActive(true);
        }
    }

   


}
