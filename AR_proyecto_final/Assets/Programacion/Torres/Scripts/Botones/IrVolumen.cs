using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IrVolumen : MonoBehaviour
{


    public GameObject Volumen;
    public GameObject PanelOCULTAR;


    private void Start()
    {
        Volumen.SetActive(false);
    }


    public void PanelOpciones()
    {
        if (Volumen != false)
        {
            bool EstaActivo = Volumen.activeSelf;

           Volumen.SetActive(!EstaActivo);
        }
        if (PanelOCULTAR != true)
        {
            bool EstaActivo = PanelOCULTAR.activeSelf;

            PanelOCULTAR.SetActive(EstaActivo);
        }

    }


}
