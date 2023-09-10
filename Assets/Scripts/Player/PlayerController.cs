using System.Collections;
using CommonComponents.Interfaces;
using PlayerInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Player
{
    public class PlayerController : InteractableActor
	{
        [FormerlySerializedAs("_input")]
		[Header("Static Setup")]
		[SerializeField] private PlayerInputBinder input;

		private Rigidbody2D _rb;
		private Animator _anim;

		private Vector2 _moveVector;
		private Vector2 _lastDirection;

		private static readonly int LastY = Animator.StringToHash("lastY");
		private static readonly int LastX = Animator.StringToHash("lastX");
		private static readonly int CurrentX = Animator.StringToHash("currentX");
		private static readonly int CurrentY = Animator.StringToHash("currentY");

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
				_anim.SetFloat(LastX, _lastDirection.x);
				_anim.SetFloat(LastY, _lastDirection.y);
			}
			_rb.velocity = _moveVector;

			_anim.SetFloat(CurrentX, _moveVector.x);
			_anim.SetFloat(CurrentY, _moveVector.y);

		}
    }
}