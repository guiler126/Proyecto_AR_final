using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrCreditos : MonoBehaviour
{


    public GameObject Creditos;
    public GameObject PanelOCULTAR;


    private void Start()
    {
        Creditos.SetActive(false);
    }


    public void PanelOpciones()
    {
        if (Creditos != false)
        {
            bool EstaActivo = Creditos.activeSelf;

            Creditos.SetActive(!EstaActivo);
        }
        if (PanelOCULTAR != true)
        {
            bool EstaActivo = PanelOCULTAR.activeSelf;

            PanelOCULTAR.SetActive(EstaActivo);
        }

    }








}
