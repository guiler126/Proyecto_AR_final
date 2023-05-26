using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;
    public Volume currentVolume;
    public Volume uiVolume; // Nuevo volumen para la UI
    public ColorAdjustments colorAdjustments;
    public ColorAdjustments uiColorAdjustments; // Nuevo componente ColorAdjustments para la UI
    private VolumeParameter<float> postExpo = new VolumeParameter<float>();

    private void Start()
    {
        currentVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        //uiVolume.profile.TryGet<ColorAdjustments>(out uiColorAdjustments); // Obtener el componente ColorAdjustments de la UI

        float savedValue = PlayerPrefs.GetFloat("BrightnessValue", 1f);

        brightnessSlider.value = savedValue;
        AdjustBrightness(savedValue);
    }

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            postExpo.value = value;
            colorAdjustments.postExposure.SetValue(postExpo);

            // Aplicar el valor de brillo también a la interfaz de usuario
            //uiColorAdjustments.postExposure.SetValue(postExpo);
        }
        else
        {
            postExpo.value = -1.25f;
            colorAdjustments.postExposure.SetValue(postExpo);

            // Aplicar el valor de brillo también a la interfaz de usuario
            //uiColorAdjustments.postExposure.SetValue(postExpo);
        }

        PlayerPrefs.SetFloat("BrightnessValue", value);
        PlayerPrefs.Save();
    }
}
