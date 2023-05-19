using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creditos : MonoBehaviour
{
    public float vel = 7f;





    private void Update()
    {
        transform.Translate(Vector3.up * vel * Time.deltaTime);
    }

}
