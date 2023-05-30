using System;
using System.Collections;
using UnityEngine;

public class Trampa_Parent : MonoBehaviour
{
    private IEnumerator current_coroutine;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject trap2;
    [SerializeField] private float timeActivate;
    [SerializeField] private float timeDeactivate;

    private void Start()
    {
        current_coroutine = Coroutine_ActivateTrap();
        StartCoroutine(current_coroutine);
    }

    IEnumerator Coroutine_ActivateTrap()
    {
        yield return new WaitForSeconds(timeActivate);

        trap.SetActive(true);
        trap2.SetActive(true);
        
        current_coroutine = Coroutine_DeactivateTrap();
        StartCoroutine(current_coroutine);
    }    
    
    IEnumerator Coroutine_DeactivateTrap()
    {
        yield return new WaitForSeconds(timeDeactivate);

        trap.SetActive(false);
        trap2.SetActive(false);

        current_coroutine = Coroutine_ActivateTrap();
        StartCoroutine(current_coroutine);
    }
}
