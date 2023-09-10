using System;
using CommonComponents;
using CommonComponents.Interfaces;
using PlayerInput;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerInteractionController : InteractableActor
	{
		[Header("Static Setup")]
		[SerializeField] private PlayerInputBinder input;

		[SerializeField] private GameObject actionDisplay;
		[SerializeField] private TMP_Text actionText;

		public void Awake()
		{
			input.InteractEvent += OnInteract;
		}

		private void OnInteract(bool obj) => ActionCurrent();

		protected override void UpdateInteractiveDisplay(Interactable interactiveObject)
		{
			if (interactiveObject == null)
			{
				actionDisplay.SetActive(false);
				return;
			}

			actionDisplay.SetActive(true);
			actionText.text = $"{interactiveObject.ActionText} the {interactiveObject.ItemName}";
		}
	}
}