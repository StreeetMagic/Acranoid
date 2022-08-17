using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        private Vector2 _direction;
        private PlayerInputActions _playerUinputActions;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _playerUinputActions = new PlayerInputActions();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerUinputActions.Player.Move.performed += ctx => OnMove();
        }

        private void FixedUpdate()
        {
            OnMove();
            Move(_direction);
        }

        private void OnEnable()
        {
            _playerUinputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _playerUinputActions.Player.Disable();
        }

        private void OnMove()
        {
            _direction = _playerUinputActions.Player.Move.ReadValue<Vector2>();
        }

        private void Move(Vector2 direction)
        {
            var scaledMoveSpeed = _moveSpeed * Time.deltaTime;
            Vector3 move = direction;
            Vector2 position = transform.position + move * scaledMoveSpeed;
            _rigidbody2D.MovePosition(position);
        }
    }
}