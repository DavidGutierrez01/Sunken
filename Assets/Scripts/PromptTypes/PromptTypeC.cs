using Cinemachine;
using UnityEngine;
using Experimental;
using UnityEngine.Events;

namespace Prompts
{
    public class PromptTypeC : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCam;
        [SerializeField] private UnityEvent _onInteractKeyDown;

        private bool _playerIsOnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Player>(out Player player)) return;

            _playerIsOnTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<Player>(out Player player)) return;

            _playerIsOnTrigger = false;
        }

        private void Update()
        {
            if (!_playerIsOnTrigger) return;

            if (!Input.GetKeyDown(KeyCode.E)) return;

            _onInteractKeyDown.Invoke();
            Debug.Log("Switching Camera");
        }
    }
}
