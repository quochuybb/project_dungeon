using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private Slider volumeSlider;
    
    public AudioClip backgroundMusic1;
    public AudioClip clickSound;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    public AudioClip backgroundMusic4;
    public AudioClip deathSound;

    public void Start()
    {
        musicSource.clip = backgroundMusic1;
        musicSource.Play();
        if (!PlayerPrefs.HasKey("BackgroundMusic"))
        {
            PlayerPrefs.SetFloat("BackgroundMusic",1f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("BackgroundMusic");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("BackgroundMusic", volumeSlider.value);
    }

    public void TurnOffMusic()
    {
        musicSource.Stop();
    }

    public void TurnOnMusic()
    {
        musicSource.Play();
    }
}
