using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    PlayerSettings playerSettings;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider masterVolumeSlider;
    
    public void SaveSettings()
    {
        playerSettings.MusicVolume = (int)musicVolumeSlider.value;
        playerSettings.SFXVolume = (int)sfxVolumeSlider.value;
        playerSettings.MasterVolume = (int)masterVolumeSlider.value;
    }
    public void Return()
    {
        FindObjectOfType<OptionsMenu>().gameObject.SetActive(false);

    }
}
