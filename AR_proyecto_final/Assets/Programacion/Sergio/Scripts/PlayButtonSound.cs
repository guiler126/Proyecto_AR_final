using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    private Button button; // Referencia al componente Button del botón
    private AudioSource audioSource; // Referencia al componente AudioSource

    private void Start()
    {
        // Obtener los componentes Button y AudioSource del botón
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // Asignar el método PlaySound al evento onClick del botón
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        // Reproducir el sonido del AudioSource
        audioSource.Play();
    }
}
