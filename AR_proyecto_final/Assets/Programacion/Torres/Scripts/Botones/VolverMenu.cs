using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;


public class VolverMenu : MonoBehaviour
{


    public GameObject menuPrincipal;
    public GameObject PanelOCULTAR;


    private void Start()
    {
        menuPrincipal.SetActive(false);
    }


    public void PanelOpciones()
    {
        if (menuPrincipal != false)
        {
            bool EstaActivo = menuPrincipal.activeSelf;

            menuPrincipal.SetActive(!EstaActivo);
        }
        if (PanelOCULTAR != true)
        {
            bool EstaActivo = PanelOCULTAR.activeSelf;

            PanelOCULTAR.SetActive(EstaActivo);
        }

    }







}
