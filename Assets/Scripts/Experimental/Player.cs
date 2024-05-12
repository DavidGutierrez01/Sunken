using Cinemachine;
using Experimental;
using UnityEngine;

namespace Experimental
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public CinemachineVirtualCamera PlayerCamera { get; private set; }

        #region Private Variables
        private bool _playerCameraEnabled;
        #endregion

        #region Components
        private PlayerMovement _playerMovement;

        #endregion

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            _playerCameraEnabled = true;
        }

        public void EnablePlayerCamera(bool value)
        {
            _playerCameraEnabled = value;
            PlayerCamera.gameObject.SetActive(_playerCameraEnabled);
        }

        public void FlipFlopPlayerCamera()
        {
            _playerCameraEnabled = !_playerCameraEnabled;
            PlayerCamera.gameObject.SetActive(_playerCameraEnabled);
        }
    }
}