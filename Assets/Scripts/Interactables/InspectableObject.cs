using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

namespace Interactables
{
    public class InspectableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCam;
        [SerializeField] private float _rotateSpeed = 2f;
        [SerializeField] private UnityEvent _onObjectInteracted;

        private bool _objectIsActive;
        private Camera _camera;

        private Vector2 deltaRotation;

        private void Start()
        {
            _camera = Camera.main;
            _objectIsActive = false;
        }

        private void Update()
        {
            if (_objectIsActive)
            {
                InspectObject();
            }
        }

        public void Interact()
        {
            _onObjectInteracted.Invoke();
            _objectIsActive = !_objectIsActive;

            Debug.Log(_objectIsActive);
        }

        private void InspectObject()
        {
            Debug.Log($"Inspecting {this.transform.name}");

            deltaRotation.x = Input.GetAxis("Mouse X");
            deltaRotation.y = Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.AngleAxis(deltaRotation.x * _rotateSpeed, _camera.transform.up) *
                Quaternion.AngleAxis(deltaRotation.y * _rotateSpeed, _camera.transform.right) * transform.rotation;
            }
        }
    }
}
