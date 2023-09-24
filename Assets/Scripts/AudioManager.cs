using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
        
        else
        {
            return;
        }
   
    }
    public void PlayRandomMusicClip()
    {
        if (!musicAudioSource.isPlaying)
        {
            musicAudioSource.clip = musicClips[Random.Range(0, musicClips.Length)];
            musicAudioSource.Play();
        }
        else
        {
            return;
        }
    }
}
