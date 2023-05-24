using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    //Variables publicas
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;
    public Image panelBrillo2;
    public Image panelBrillo3;
    public Image panelBrillo4;
    public Image panelBrillo5;
    public Image panelBrillo6;
    


    void Start()
    {

        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);

        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
        panelBrillo2.color = new Color(panelBrillo2.color.r, panelBrillo2.color.g, panelBrillo2.color.b, slider.value);
        panelBrillo3.color = new Color(panelBrillo3.color.r, panelBrillo3.color.g, panelBrillo3.color.b, slider.value);
        panelBrillo4.color = new Color(panelBrillo4.color.r, panelBrillo4.color.g, panelBrillo4.color.b, slider.value);
        panelBrillo5.color = new Color(panelBrillo5.color.r, panelBrillo5.color.g, panelBrillo5.color.b, slider.value);
        panelBrillo6.color = new Color(panelBrillo6.color.r, panelBrillo6.color.g, panelBrillo6.color.b, slider.value);
        
    }

   
    public void CambiarSider(float valor)
    {
        sliderValue = valor;
        sliderValue = valor;
        sliderValue = valor;
        sliderValue = valor;
        sliderValue = valor;
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
        panelBrillo2.color = new Color(panelBrillo2.color.r, panelBrillo2.color.g, panelBrillo2.color.b, slider.value);
        panelBrillo3.color = new Color(panelBrillo3.color.r, panelBrillo3.color.g, panelBrillo3.color.b, slider.value);
        panelBrillo4.color = new Color(panelBrillo4.color.r, panelBrillo4.color.g, panelBrillo4.color.b, slider.value);
        panelBrillo5.color = new Color(panelBrillo5.color.r, panelBrillo5.color.g, panelBrillo5.color.b, slider.value);
        panelBrillo6.color = new Color(panelBrillo6.color.r, panelBrillo6.color.g, panelBrillo6.color.b, slider.value);
    }
}
