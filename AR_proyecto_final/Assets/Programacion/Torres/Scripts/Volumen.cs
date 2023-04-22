using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarMute();
    }

    public void CambiarSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarMute();

    }
    
   
    public void RevisarMute()
    {
    
        if(sliderValue == 0)
        {
            imagenMute.enabled = true;


        }
        else
        {
            imagenMute.enabled = false;
        }
    
    
    
    }






}
