using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IrIdiomas : MonoBehaviour
{
    public GameObject Idiomas;
    public GameObject PanelOCULTAR;


   

    public void PanelOpciones()
    {
        if (Idiomas != false)
        {
            bool EstaActivo = Idiomas.activeSelf;

            Idiomas.SetActive(!EstaActivo);
        }
        if (PanelOCULTAR != true)
        {
            bool EstaActivo = PanelOCULTAR.activeSelf;

            PanelOCULTAR.SetActive(EstaActivo);
        }

    }


}
