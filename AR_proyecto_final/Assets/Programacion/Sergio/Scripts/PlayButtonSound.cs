using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    private Button button; // Referencia al componente Button del bot�n
    private AudioSource audioSource; // Referencia al componente AudioSource

    private void Start()
    {
        // Obtener los componentes Button y AudioSource del bot�n
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // Asignar el m�todo PlaySound al evento onClick del bot�n
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        // Reproducir el sonido del AudioSource
        audioSource.Play();
    }
}
