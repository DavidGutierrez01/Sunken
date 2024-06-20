using Cinemachine;
using UnityEngine;
using Experimental;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerInteract))]
    public class Player : MonoBehaviour
    {
        [field: Header("Player Setup")]
        [field: SerializeField] public CinemachineVirtualCamera PlayerCamera { get; private set; }

        public static Player Instance;

        #region Private Variables
        private bool _playerCameraEnabled;
        #endregion

        #region Components
        private PlayerMovement _playerMovement;
        private PlayerInteract _playerInteract;

        #endregion

        private void Awake()
        {

            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;


            _playerMovement = GetComponent<PlayerMovement>();
            _playerInteract = GetComponent<PlayerInteract>();
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