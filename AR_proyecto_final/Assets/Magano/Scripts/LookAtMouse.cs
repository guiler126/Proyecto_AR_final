using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float speed;

    public static LookAtMouse instance;


    private void Update()
    {
        LookAtCursor();
    }

    private void Awake()
    {
        instance = this;
    }

    public void LookAtCursor()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            
            Quaternion targetRotation = Quaternion.LookRotation(targetpoint-transform.position);
            
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,speed*Time.deltaTime);
        }
    }
}
