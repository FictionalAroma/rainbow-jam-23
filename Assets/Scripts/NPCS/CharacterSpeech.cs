using System.Collections;
using CommonComponents;
using CommonComponents.Interfaces;
using Interactions;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


public class CharacterSpeech : Interactable
{
	[SerializeField] protected string speechText;
	[SerializeField] private TMP_Text speechBubble;
	[SerializeField] private GameObject speechCanvas;
    [SerializeField] float typingDelay;
    public Image currentImage;
    public TextMeshProUGUI dialogueTextDisplay;
    private Coroutine _currentSpeech = null;
    [SerializeField] Sprite npcImage;
    AudioSource npcAudioSource;
    public AudioClip[] dialogueClips;
    public int audioFrequency = 2;
    [Range(1.3f, 2f)][SerializeField] float minPitch;
    [Range(1.3f, 2f)][SerializeField] float maxPitch;
    public override bool Action(InteractableActor interactableActor)
	{
        /*if (_currentSpeech != null)
		{
			StopCoroutine(_currentSpeech);
		}
		_currentSpeech = StartCoroutine(ShowSpeech());
		return true;*/
        StartCoroutine(CaptainMessage(speechText, npcImage));
        return true;
    }

		return true;
	}
    public IEnumerator NPCMessage(string text, Sprite npcImage)
    {
        speechCanvas.SetActive(true);
        speechBubble.text = text;
        dialogueTextDisplay.maxVisibleCharacters = 0;
        foreach (char c in text)
        {

            currentImage.sprite = npcImage;
            PlayAudioClips(dialogueTextDisplay.maxVisibleCharacters);
            dialogueTextDisplay.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingDelay);
        }
        speechCanvas.SetActive(false);

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
            AudioClip randomClip = dialogueClips[Random.Range(0, dialogueClips.Length)];
            npcAudioSource.clip = randomClip;
            npcAudioSource.pitch = Random.Range(minPitch, maxPitch);
            npcAudioSource.Play();
        }
    }
}
