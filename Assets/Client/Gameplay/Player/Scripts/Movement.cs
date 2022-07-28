using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;

        private Rigidbody2D _rigidbody2D;
        PlayerInputActions _playerUinputActions;
        private Vector2 _direction;
        private float _xBorder = 8.3f;
        private float _yBorder = 4.2f;

        private void Awake()
        {
            _playerUinputActions = new PlayerInputActions();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerUinputActions.Player.Move.performed += ctx => OnMove();
        }

        private void Update()
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
            float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
            Vector3 move = direction;
            transform.position += move * scaledMoveSpeed;

            if (transform.position.x < -_xBorder)
            {
                transform.position = new Vector3(-_xBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.x > _xBorder)
            {
                transform.position = new Vector3(_xBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.y < -_yBorder)
            {
                transform.position = new Vector3(transform.position.x, -_yBorder, transform.position.z);
            }
            if (transform.position.y > _yBorder)
            {
                transform.position = new Vector3(transform.position.x, _yBorder, transform.position.z);
            }
        }
    }
}
