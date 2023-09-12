using System.Collections;
using CommonComponents;
using CommonComponents.Interfaces;
using Interactions;
using TMPro;
using UnityEngine;


public class CharacterSpeech : Interactable
{
	[SerializeField] protected string speechText;
	[SerializeField] private SpeechBubble speechBubble;
	private bool _canActivate = true;

	public override bool Action(InteractableActor interactableActor)
	{
		if (_canActivate)
		{
			speechBubble.Activate(speechText, () => _canActivate = true);
			_canActivate = false;
		}

		return true;
	}
}
