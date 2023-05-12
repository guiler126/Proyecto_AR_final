using UnityEngine;

public class DetenerParticulas12 : MonoBehaviour
{
    [System.Serializable]
    public struct ParticulaDetenida
    {
        public ParticleSystem particula;
        public float tiempoDetencion;
    }

    public ParticulaDetenida[] particulasDetenidas;

    private bool detenerParticulas = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !detenerParticulas)
        {
            detenerParticulas = true;
            StartCoroutine(DetenerParticulasPorTiempo());
        }
    }

    private System.Collections.IEnumerator DetenerParticulasPorTiempo()
    {
        foreach (ParticulaDetenida particulaDetenida in particulasDetenidas)
        {
            particulaDetenida.particula.Stop();
            yield return new WaitForSeconds(particulaDetenida.tiempoDetencion);
            
        }

        detenerParticulas = true;
    }
}
