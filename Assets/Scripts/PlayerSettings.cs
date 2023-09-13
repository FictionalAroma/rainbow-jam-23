using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings
{

    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public void SetInt(string key, int value)
    {
         PlayerPrefs.SetInt(key, value);
    }
    public string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    public void  SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
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
