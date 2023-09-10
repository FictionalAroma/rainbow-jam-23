using System.Collections;
using CommonComponents.Interfaces;
using PlayerInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Player
{
	public class PlayerAnimator
	{
		public static readonly int LastY = Animator.StringToHash("lastY");
		public static readonly int LastX = Animator.StringToHash("lastX");
		public static readonly int CurrentX = Animator.StringToHash("currentX");
		public static readonly int CurrentY = Animator.StringToHash("currentY");
	}

	public class PlayerController : InteractableActor
	{
        [FormerlySerializedAs("_input")]
		[Header("Static Setup")]
		[SerializeField] private PlayerInputBinder input;

		private Rigidbody2D _rb;
		private Animator _anim;

		private Vector2 _moveVector;
		private Vector2 _lastDirection;

		void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
			_anim = GetComponent<Animator>();
			BindInputEvents();
		}

		void OnDestroy()
		{
			UnbindInputEvents();
		}

		private void BindInputEvents()
		{
			input.MoveEvent += OnMove;
			input.InteractEvent += OnInteract;
		}

		private void UnbindInputEvents()
        {
            input.MoveEvent -= OnMove;
            input.InteractEvent -= OnInteract;
        }

        private void OnMove(Vector2 moveVector) => _moveVector = moveVector;

		private void OnInteract(bool button) => ActionCurrent();

		// Update is called once per frame
        void FixedUpdate()
		{
			if (_moveVector != Vector2.zero)
			{
				_lastDirection = _moveVector;
				_anim.SetFloat(PlayerAnimator.LastX, _lastDirection.x);
				_anim.SetFloat(PlayerAnimator.LastY, _lastDirection.y);
			}
			_rb.velocity = _moveVector;

			_anim.SetFloat(PlayerAnimator.CurrentX, _moveVector.x);
			_anim.SetFloat(PlayerAnimator.CurrentY, _moveVector.y);

		}
    }
}