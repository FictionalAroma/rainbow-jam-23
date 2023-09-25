using UnityEngine;

public class GameManager : MonoBehaviour
{

    PlayerSettings playerSettings;
    int sfxVolume;
    int ambienceVolume;
    int musicVolume;
    int fontSize;
    string font;
    AudioManager audioManager;
    private void Awake()
	{
		playerSettings = new PlayerSettings();
	}
    void Start()
    {
        sfxVolume = playerSettings.GetInt("sfxVolume");
        musicVolume = playerSettings.GetInt("musicVolume");
        fontSize = playerSettings.GetInt("fontSize");
        ambienceVolume = playerSettings.GetInt("ambienceVolume");
        audioManager = GetComponent<AudioManager>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        audioManager.musicAudioSource.volume = musicVolume;
        audioManager.ambienceAudioSource.volume= ambienceVolume;
        if (!audioManager.musicAudioSource.isPlaying)
        {
            audioManager.PlayRandomMusicClip();
        }
        if (!audioManager.ambienceAudioSource.isPlaying)
        {
            audioManager.PlayRandomAmbienceClip();
        }
    }
}
