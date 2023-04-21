using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SPAWN : MonoBehaviour
{

    public GameObject Boss;
    public bool Activo;
    //public Animator ANIM;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Activo = true;
            Boss.SetActive(true);
            //GetComponent<Animator>().SetBool("EstoyCorriendo", true);

        }
    }

   
}
