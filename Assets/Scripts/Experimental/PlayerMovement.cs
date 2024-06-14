using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Experimental
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Attributes")]
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _playerJumpHeight;

        [Header("Collision Attributes")]
        [SerializeField] private bool _showGizmo;
        [SerializeField] Vector3 _groundColliderSize;


        #region Components  
        public Rigidbody RigidBody { get; private set; }
        private PlayerInput _playerInput;
        #endregion

        #region Private Variables

        private Vector3 _playerPosition;

        #endregion

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();
        }

        public void PlayerMove(InputAction.CallbackContext context)
        {
            _playerPosition = context.ReadValue<Vector3>();
        }

        public void PlayerJump(InputAction.CallbackContext context)
        {
            // if (!IsGrounded()) return;

            RigidBody.AddForce(transform.up * _playerJumpHeight, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            RigidBody.MovePosition(transform.position + _playerPosition * Time.deltaTime * _playerSpeed);
        }

        private void OnCollisionEnter(Collision other)
        {

        }

        private bool IsGrounded()
        {
            return Physics.OverlapBox(transform.position, );
        }


        private void OnDrawGizmos()
        {
            if (_showGizmo)
                Gizmos.DrawCube(transform.position, _groundColliderSize);
        }
    }
}