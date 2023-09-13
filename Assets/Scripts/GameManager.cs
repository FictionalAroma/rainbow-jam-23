using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    PlayerSettings playerSettings;
    int sfxVolume;
    int musicVolume;
    int fontSize;
    string font;
    private void Awake()
    {
        
    }
    void Start()
    {
        sfxVolume = playerSettings.sfxVolumeSet;
        musicVolume = playerSettings.musicVolumeSet;
        fontSize = playerSettings.fontSizeSet;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
