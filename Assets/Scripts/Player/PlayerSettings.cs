using UnityEngine;

public class PlayerSettings
{
    private int? _masterVolume;
    private int? _sfxVolume;
    private int? _musicVolume;
    private string _font;
    private int? _fontSize;
    public int MasterVolume
    {
        get
        {
            if (!_masterVolume.HasValue)
            {
                _masterVolume = GetInt("MasterVolume");
            }
            return _masterVolume.Value;
        }
        set
        {
            SetInt("MasterVolume", value);
            _masterVolume = value;
        }
    }
    public int SFXVolum
    {
        get
        {
            if (!_sfxVolume.HasValue)
            {
                _sfxVolume = GetInt("SFXVolume");

            }
            return _sfxVolume.Value;
        }
        set
        {
            SetInt("SFXVolume", value);
			_sfxVolume = value;
        }
    }
    public int MusicVolume
    {
        get
        {
            if (!_musicVolume.HasValue)
            {
                _musicVolume = GetInt("MusicVolume");
            }
            return _musicVolume.Value;
        }
        set
        {
            SetInt("MusicVolume",value);
            _musicVolume = value;
        }
    }
    public int FontSize
    {
        get
        {
            if(!_fontSize.HasValue)
            {
                _fontSize = GetInt("FontSize");
            }
            return _fontSize.Value;
        }
        set
        {
            SetInt("FontSize", value);
            _fontSize = value;
        }
    }
    public string Font
    {
        get
        {
            if(string.IsNullOrEmpty(_font))
            {
                _font = GetString("Font");
            }
            return _font;
        }
        set
        {
            SetString("Font", value);
            _font = value;
        }
    }
    public void ForceReload()
    {
        _fontSize = null;
        _font = null;
        _masterVolume = null;
        _musicVolume = null;
        
    }
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
    public void SetString(string key, string value)
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
   

    
}
