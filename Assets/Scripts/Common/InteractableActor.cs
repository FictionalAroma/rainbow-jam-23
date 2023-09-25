using System.Collections.Generic;
using UnityEngine;

namespace CommonComponents.Interfaces
{
	[RequireComponent(typeof(Collider2D))]
	public abstract class InteractableActor : MonoBehaviour
	{
        protected Interactable InteractiveObject = null;
		[SerializeField] private Collider2D actionTrigger;
		

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (InteractiveObject != null)
			{
				InteractiveObject = GetClosestInteractable();
			}
			else if (other.gameObject.TryGetComponent<Interactable>(out var obj))
			{
				InteractiveObject = obj;
			}

			UpdateInteractiveDisplay(InteractiveObject);
		}

		protected abstract void UpdateInteractiveDisplay(Interactable interactiveObject);

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.TryGetComponent<Interactable>(out var obj))
			{
				InteractiveObject = GetClosestInteractable();
			}
			UpdateInteractiveDisplay(InteractiveObject);
		}

		private readonly List<Collider2D> _colliderTest = new List<Collider2D>(5);
		private readonly List<Interactable> _interactibleContactList = new List<Interactable>(2);
		private Interactable GetClosestInteractable()
		{
			_colliderTest.Clear();
			int numberContacts = actionTrigger.GetContacts(_colliderTest);
			if (numberContacts == 0) return null;

			_interactibleContactList.Clear();
			foreach (var col in _colliderTest)
			{
				if (col.TryGetComponent<Interactable>(out var obj))
				{
					_interactibleContactList.Add(obj);
				}
			}

			switch (_interactibleContactList.Count)
			{
				case 0: return null;
				case 1: return _interactibleContactList[0];
				default:
				{
					var chosen = _interactibleContactList[0];
					float distance = chosen.GetDistance(actionTrigger);
					for (int index = 1; index < _interactibleContactList.Count; index++)
					{
						var item = _interactibleContactList[index];
						var testDisance = item.GetDistance(actionTrigger);
						if (testDisance < 0f && testDisance > distance)
						{
							chosen = item;
							distance = testDisance;
						}
					}

					return chosen;
				}
			}
		}

		public virtual bool ActionCurrent() => InteractiveObject != null && InteractiveObject.Action(this);

	}
}