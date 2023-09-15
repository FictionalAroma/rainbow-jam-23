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
		playerSettings = new PlayerSettings();
	}
    void Start()
    {
        sfxVolume = playerSettings.GetInt("sfxVolume");
        musicVolume = playerSettings.GetInt("musicVolume");
        fontSize = playerSettings.GetInt("fontSize");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
