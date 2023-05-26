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
    private VolumeParameter<float> postExpo = new VolumeParameter<float>();

    private void Start()
    {
        currentVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        

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
             
        }
        else
        {
            postExpo.value = -1.25f;
            colorAdjustments.postExposure.SetValue(postExpo);
            
        }
        PlayerPrefs.SetFloat("BrightnessValue", value);
        PlayerPrefs.Save();
    }
}
