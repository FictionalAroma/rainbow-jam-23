
using System;
using System.Collections;
using System.Collections.Generic;
using ExtensionClasses;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectGenerator : MonoBehaviour
{
	[SerializeField] private List<AudioClip> clipList;
	[SerializeField] private AudioSource player;
	private Coroutine currentSoundRun;

	// Start is called before the first frame update
	private void Start()
	{
		if (player.IsUnityNull())
		{
			player = GetComponent<AudioSource>();
		}
	}

	public void PlayRandomSound()
	{
		player.PlayOneShot(clipList.RandomFromList());
	}

	/// <summary>
	/// Plays a number of random sounds with a fixed delay in the middle
	/// </summary>
	/// <param name="number"></param>
	/// <param name="delay"></param>
	public void PlayRandomSoundsWithFixedDelay(int number, float delayBetween = 0.25f, bool delayInitial = false)
	{
		currentSoundRun = StartCoroutine(PlayRandomSoundsWithFixedDelayRoutine(number, delayBetween, delayInitial));
	}

	private IEnumerator PlayRandomSoundsWithFixedDelayRoutine(int number, float delay,  bool delayInitial)
	{
		if (delayInitial) yield return new WaitForSeconds(delay);
		for (int index = 0; index < number; index++)
		{
			player.PlayOneShot(clipList.RandomFromList());
			yield return new WaitForSeconds(delay);
		}

		currentSoundRun = null;
	}
	public void PlayRandomSoundsStringTogether(int number, float delayBetween = 0.1f, bool delayInitial = false)
	{
		currentSoundRun = StartCoroutine(PlayRandomSoundsWithFixedDelayRoutine(number, delayBetween, delayInitial));
	}


	private IEnumerator PlayRandomSoundsStringTogetherRoutine(int number, float delay,  bool delayInitial)
	{
		if (delayInitial) yield return new WaitForSeconds(delay);
		for (int index = 0; index < number; index++)
		{
			var clip = clipList.RandomFromList();
			player.PlayOneShot(clip);
			yield return new WaitForSeconds(clip.length + delay);
		}

		currentSoundRun = null;
	}

	public void StopSounds()
	{
		if (currentSoundRun != null)
		{
			StopCoroutine(currentSoundRun);
		}
	}

}
