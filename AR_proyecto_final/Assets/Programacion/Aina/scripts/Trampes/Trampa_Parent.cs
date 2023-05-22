using System.Collections;
using UnityEngine;

public class Trampa_Parent : MonoBehaviour
{
    private IEnumerator current_coroutine;
    public PoolingItemsEnum trapEnum;
    private GameObject trap;
    [SerializeField] private float timeActivate;
    
    private void OnTriggerEnter(Collider other)
    {
        trap = PoolingManager.Instance.GetPooledObject((int)trapEnum);
        trap.transform.position = gameObject.transform.position;
        
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            current_coroutine = Coroutine_DeactivateTrap();
            StartCoroutine(current_coroutine);
        }
    }

    IEnumerator Coroutine_DeactivateTrap()
    {
        yield return new WaitForSeconds(timeActivate);
        // add animations 
        trap.SetActive(false);
    }
}
