using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings
{

    public void GetInt(string key)
    {
        PlayerPrefs.GetInt(key);
    }
    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public void GetString(string key)
    {
        PlayerPrefs.GetString(key);
    }
    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public void GetFloat(string key)
    {
        PlayerPrefs.GetFloat(key);
    }
    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    

    /*public void SaveSettings()
    {
        PlayerPrefs.SetInt("sfxVolume", sfxVolumeSet);
        PlayerPrefs.SetInt("musicVolume", musicVolumeSet);
        PlayerPrefs.SetInt("fontSize", fontSizeSet);
    }*/
    
}
