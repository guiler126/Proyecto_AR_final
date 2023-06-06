using UnityEngine;
using System.Collections.Generic;

public class SoundController : MonoBehaviour
{
    public List<AudioSource> masterSoundSources = new List<AudioSource>();
    public List<AudioSource> sfxSoundSources = new List<AudioSource>();

    public float masterVolume = 1f;
    public float sfxVolume = 1f;

    private void Start()
    {
        // Obtener todas las instancias de AudioSource en tu juego
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        // Clasificar los AudioSource en las listas correspondientes
        foreach (AudioSource source in audioSources)
        {
            if (source.CompareTag("SonidoMaster"))
            {
                masterSoundSources.Add(source);
            }
            else if (source.CompareTag("SonidoVFX"))
            {
                sfxSoundSources.Add(source);
            }
        }
    }


    public void SetMasterVolume(float volume)
    {
        // Actualizar el volumen de la categoría SonidoMaster
        masterVolume = volume;

        // Actualizar el volumen de la categoría SonidoMaster
        foreach (AudioSource source in masterSoundSources)
        {
            source.volume = masterVolume;
        }
    }

    public void SetSFXVolume(float volume)
    {
        // Actualizar el volumen de la categoría SonidoVFX
        sfxVolume = volume;

        // Actualizar el volumen de la categoría SonidoVFX
        foreach (AudioSource source in sfxSoundSources)
        {
            source.volume = sfxVolume;
        }
    }
}
