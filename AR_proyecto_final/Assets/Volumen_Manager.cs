using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen_Manager : MonoBehaviour
{
    [Header("musica")]
    public Slider sliderMusica;
    public Slider sliderVFX;
    public float slidervalueMusica;
    public float slidervaluevfx;
    public AudioSource sourceMusica;
    public AudioSource sourceVFX;


    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volmenMusica");
        sliderMusica.value = PlayerPrefs.GetFloat("volmenMusica");

        sliderVFX.value = PlayerPrefs.GetFloat("volmenVFX");
    }

    public void slidermusica(float valorMusica)
    {
        slidervalueMusica = valorMusica;
        PlayerPrefs.SetFloat("volmenMusica", slidervalueMusica);
        sourceMusica.volume = sliderMusica.value;
        //musicaMute();

    }
    public void slidervfx(float valorVFX)
    {
        slidervaluevfx = valorVFX;
        PlayerPrefs.SetFloat("volmenVFX", slidervaluevfx);
        sourceVFX.volume = sliderVFX.value;
        //musicaMute();

    }

    public void MasterVolume()
    {
        AudioListener.volume = sliderMusica.value;

        PlayerPrefs.SetFloat("volmenMusica", sliderMusica.value);
    }
}
