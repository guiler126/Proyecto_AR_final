using System.Collections;
using UnityEngine;

public class Trampa_Parent : MonoBehaviour
{
    private IEnumerator current_coroutine;
    public PoolingItemsEnum trapEnum;
    private GameObject trap;
    [SerializeField] private float timeActivate;
    [SerializeField] private float timeDeactivate;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            current_coroutine = Coroutine_ActivateTrap();
            StartCoroutine(current_coroutine);
        }
    }

    IEnumerator Coroutine_ActivateTrap()
    {
        yield return new WaitForSeconds(timeActivate);

        trap.SetActive(trap);
        
        current_coroutine = Coroutine_DeactivateTrap();
        StartCoroutine(current_coroutine);
    }    
    
    IEnumerator Coroutine_DeactivateTrap()
    {
        yield return new WaitForSeconds(timeDeactivate);

        trap.SetActive(false);
    }
}
