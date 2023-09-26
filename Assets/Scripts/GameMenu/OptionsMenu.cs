using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    PlayerSettings playerSettings;
    Slider sfxVolumeSlider;
    Slider musicVolumeSlider;
    Slider ambienceVolumeSlider;
    
    public void SaveSettings()
    {
        playerSettings.MusicVolume = (int)musicVolumeSlider.value;
        playerSettings.SFXVolume = (int)sfxVolumeSlider.value;
       
    }
}
