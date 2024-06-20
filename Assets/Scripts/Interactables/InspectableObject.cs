using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

namespace Interactables
{
    public class InspectableObject : MonoBehaviour, IPickupable
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCam;
        [SerializeField] private float _rotateSpeed = 2f;
        [SerializeField] private UnityEvent _onObjectInteracted;

        private bool _objectIsHeld;

        private Vector2 deltaRotation;

        private void Start()
        {
            _objectIsHeld = false;
        }

        private void Update()
        {
            if (_objectIsHeld)
            {
                InspectObject();
            }
        }

        /*
        public void Interact()
        {
            _onObjectInteracted.Invoke();
            _objectIsHeld = !_objectIsHeld;

            Debug.Log(_objectIsHeld);
        }
        */

        private void InspectObject()
        {
            deltaRotation.x = Input.GetAxis("Mouse X");
            deltaRotation.y = Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.AngleAxis(deltaRotation.x * _rotateSpeed, Vector3.down) *
                Quaternion.AngleAxis(deltaRotation.y * _rotateSpeed, Vector3.right) * transform.rotation;

                Debug.Log($"{transform.name} is being inspected");
            }
        }

        public void Hold()
        {
            _objectIsHeld = true;
            Debug.Log($"{transform.name} held");
        }

        public void Drop()
        {
            _objectIsHeld = false;
            Debug.Log($"{transform.name} dropped");
        }
    }
}

