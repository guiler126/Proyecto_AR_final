using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private AudioSource _backgroundAudio;
    [SerializeField] private AudioSource _effectsAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffectSound(AudioClip clip)
    {
        _effectsAudio.PlayOneShot(clip);
    }
    
    public void ChangeBackgroundMusic(AudioClip clip)
    {
        _backgroundAudio.clip = clip;
        _backgroundAudio.Play();
    }
}
