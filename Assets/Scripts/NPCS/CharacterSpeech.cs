using System.Collections;
using CommonComponents;
using CommonComponents.Interfaces;
using TMPro;
using UnityEngine;


public class CharacterSpeech : Interactable
{
	[SerializeField] protected string speechText;
	[SerializeField] private TMP_Text speechBubble;
	[SerializeField] private GameObject speechCanvas;

	private Coroutine _currentSpeech = null;

	public override bool Action(InteractableActor interactableActor)
	{
		if (_currentSpeech != null)
		{
			StopCoroutine(_currentSpeech);
		}
		_currentSpeech = StartCoroutine(ShowSpeech());
		return true;
	}

	private IEnumerator ShowSpeech()
	{
		speechCanvas.SetActive(true);
		speechBubble.text = speechText;
		yield return new WaitForSeconds(3);
		speechCanvas.SetActive(false);
		_currentSpeech = null;
	}
}
