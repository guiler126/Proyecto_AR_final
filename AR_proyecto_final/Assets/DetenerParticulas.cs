using UnityEngine;

public class DetenerParticulas : MonoBehaviour
{
    public ParticleSystem[] particulas;
    public float tiempoDetencion = 3f;

    private bool detenerParticulas = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            detenerParticulas = true;
            Invoke("ReanudarParticulas", tiempoDetencion);
            DetenerSistemasDeParticulas();
        }
    }

    private void DetenerSistemasDeParticulas()
    {
        foreach (ParticleSystem 
            particula in particulas)
        {
            
            particula.Stop();
        }
    }

    
}
