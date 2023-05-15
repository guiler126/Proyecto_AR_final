using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa_Parent : MonoBehaviour
{
    private IEnumerator current_coroutine;
    public PoolingItemsEnum trapEnum;
    private GameObject trap;
    
    private void OnTriggerEnter(Collider other)
    {
        trap = PoolingManager.Instance.GetPooledObject((int)trapEnum);
        trap.transform.position = gameObject.transform.position;
        
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            trap.SetActive(true);
            current_coroutine = Coroutine_DeactivateTrap();
            StartCoroutine(current_coroutine);
        }
    }

    IEnumerator Coroutine_DeactivateTrap()
    {
        yield return new WaitForSeconds(5f);
        // add animations 
        trap.SetActive(false);
    }
}
