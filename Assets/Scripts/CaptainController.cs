using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCTextController : MonoBehaviour
{
    [Header("Properties")]
    AudioSource npcAudioSource;
    Canvas canvas;


    [Header("Text")]
    [SerializeField] Sprite npcImage;
    public Image currentImage;
    [SerializeField] string[] dialogues;
    [SerializeField] float typingDelay;
    public TextMeshProUGUI dialogueTextDisplay;


    [Header("Dialogue")]
    public AudioClip[] dialogueClips;
    public int audioFrequency = 2;
    [Range(1.3f, 2f)] [SerializeField] float minPitch;
    [Range(1.3f, 2f)] [SerializeField] float maxPitch;
    
    
    public bool playText;
    
    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        npcAudioSource = GetComponent<AudioSource>();
        canvas.enabled = false;
    }
  
    private void Update()
    {
        if (playText)
        {
            StartCoroutine(CaptainMessage(dialogues[0], npcImage));
            playText= false;
        }
    }
    public IEnumerator CaptainMessage(string text,Sprite captainImage)
    {
        canvas.enabled = true;
        dialogueTextDisplay.text = text;
        dialogueTextDisplay.maxVisibleCharacters = 0;
        foreach (char c in text)
        {
            
            currentImage.sprite = captainImage;
            PlayAudioClips(dialogueTextDisplay.maxVisibleCharacters);
            dialogueTextDisplay.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingDelay);
        }
        canvas.enabled = false;

        /*textWords = new List<string>();
        foreach (string s in splittedStringArray)
        {
            textWords.Add(s);
        }*/

    }
    public void PlayAudioClips(int currentDisplayedCharacterCount)
    {
        if (currentDisplayedCharacterCount % audioFrequency == 0)
        {
            AudioClip randomClip = dialogueClips[UnityEngine.Random.Range(0, dialogueClips.Length)];
            npcAudioSource.clip = randomClip;
            npcAudioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
            npcAudioSource.Play();
        }
    }
    /*public void StartDialogue()
    {
        CreateText(dialogues[0]);
        PlayDialogue(textWords.Count);
    }*/


    /*public void PlayDialogue(int sentenceLength)
    {
        StartCoroutine(PlayAudioClipsCoroutine(sentenceLength));
    }

    private IEnumerator PlayAudioClipsCoroutine(int sentenceLength)
    {
        for (int sentencePlayed = 0; sentencePlayed < sentenceLength; sentencePlayed++)
        {
            AudioClip randomClip = dialogueClips[UnityEngine.Random.Range(0, dialogueClips.Length)];
            captainAudioSource.clip = randomClip;
            captainAudioSource.Play();

            // Wait until the audio clip finishes playing
            yield return new WaitForSeconds(randomClip.length);
        }
    }*/

}
