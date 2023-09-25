using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Interactions
{
	public class SpeechBubble : MonoBehaviour
	{
		[SerializeField] private TMP_Text speechText;
		private Coroutine _activeSpeech;
		public void Activate(string textToDisplay, Action onCompleteCallback = null)
		{
			speechText.enabled = true;
			this.gameObject.SetActive(true);

			if (_activeSpeech != null)
			{
				StopCoroutine(_activeSpeech);
			}
			_activeSpeech = StartCoroutine(ShowSpeechBubble(textToDisplay, onCompleteCallback));
		}

		private IEnumerator ShowSpeechBubble(string textToDisplay, Action onCompleteCallback)
		{
			speechText.text = textToDisplay;

			yield return new WaitForSeconds(3f);

			speechText.enabled = false;
			this.gameObject.SetActive(false);
			onCompleteCallback?.Invoke();
		}

	}
}