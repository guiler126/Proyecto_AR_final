using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public GameObject MenuPrincipal;


    private void Start()
    {
        MenuPrincipal.SetActive(false);
    }


    public void PanelMenu()
    {
        if(MenuPrincipal != null)
        {
            bool IsActive = MenuPrincipal.activeSelf;

            MenuPrincipal.SetActive(!IsActive);
        }
    }









}
