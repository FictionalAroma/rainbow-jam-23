using UnityEngine;

namespace CommonComponents.Interfaces
{
	public class InteractableActor : MonoBehaviour
	{
		protected Interactable InteractiveObject;

		public void SetInteractableObject(Interactable interactiveObject)
		{
			InteractiveObject = interactiveObject;
			Debug.Log($"CurrentObject = {InteractiveObject}");

		}

		public void ResetInteractableObject(Interactable interactable)
		{
			if (InteractiveObject == interactable)
			{
				InteractiveObject = null;
			}
		}

		public bool ActionCurrent()
		{
			return InteractiveObject != null && InteractiveObject.Action(this);
		}
	}
}