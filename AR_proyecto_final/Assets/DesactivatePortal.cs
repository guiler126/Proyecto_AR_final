using UnityEngine;

public class DesactivatePortal : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("Desactivate", 3f);

    }


    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
