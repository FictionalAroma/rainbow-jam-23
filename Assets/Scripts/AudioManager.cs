using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoSingleton<AudioManager>
{
	[SerializeField] private AudioMixerGroup mixer;
    public AudioSource musicAudioSource;
    public AudioSource ambienceAudioSource;
    [SerializeField] AudioClip[] ambienceClips;
    [SerializeField] AudioClip[] musicClips;

    public void PlayRandomAmbienceClip()
    {
        if (ambienceClips.Length >0)
        {
            if (!ambienceAudioSource.isPlaying)
            {
                ambienceAudioSource.clip = ambienceClips[Random.Range(0, ambienceClips.Length)];
                ambienceAudioSource.Play();
            }
        }
	}
    public void PlayRandomMusicClip()
    {
        if (!musicAudioSource.isPlaying)
        {
            musicAudioSource.clip = musicClips[Random.Range(0, musicClips.Length)];
            musicAudioSource.Play();
        }
    }
}
