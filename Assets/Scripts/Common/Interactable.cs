using CommonComponents.Interfaces;
using UnityEngine;

namespace CommonComponents
{
	[RequireComponent(typeof(Collider2D))]
	public abstract class Interactable : MonoBehaviour
	{
		[SerializeField] protected string actionText;
		[SerializeField] protected string itemName;
		[SerializeField] protected Collider2D interactionCollider;

		public Collider2D InteractionCollider => interactionCollider;
		public string ActionText => actionText;
		public string ItemName { get => itemName; set => itemName = value; }

		public abstract bool Action(InteractableActor interactableActor);
		public float GetDistance(Collider2D actionTrigger) => actionTrigger.Distance(interactionCollider).distance;
	}
}