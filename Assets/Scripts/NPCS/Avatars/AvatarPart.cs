using UnityEngine;

namespace NPCS.Avatars
{
	public static class AvatarAnimator
	{

		public static readonly int LastY = Animator.StringToHash("lastY");
		public static readonly int LastX = Animator.StringToHash("lastX");
		public static readonly int CurrentX = Animator.StringToHash("currentX");
		public static readonly int CurrentY = Animator.StringToHash("currentY");
	}

	[RequireComponent(typeof(Animator))]
	public class AvatarPart : MonoBehaviour
	{
		[SerializeField] private Animator partAnimator;
		private Vector2 _lastVel;
		public void UpdateVelocity(Vector2 newVelocity)
		{
			partAnimator.SetFloat(AvatarAnimator.LastX, _lastVel.x);
			partAnimator.SetFloat(AvatarAnimator.LastY, _lastVel.y);
			partAnimator.SetFloat(AvatarAnimator.CurrentX, newVelocity.x);
			partAnimator.SetFloat(AvatarAnimator.CurrentY, newVelocity.y);
			_lastVel = newVelocity;
		}

		public void SetRuntimeAnimation(AnimatorOverrideController bit)
		{
			partAnimator.runtimeAnimatorController = bit;
		}
	}
}