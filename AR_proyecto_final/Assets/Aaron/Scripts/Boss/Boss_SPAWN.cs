using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_SPAWN : MonoBehaviour
{

    public GameObject Boss;
    public bool Activo;
    public GameObject Boss_Panel;
    //public Animator ANIM;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Activo = true;
            Boss.SetActive(true);
            Boss_Panel.SetActive(true); 
            //GetComponent<Animator>().SetBool("EstoyCorriendo", true);

        }

    }

   
}
