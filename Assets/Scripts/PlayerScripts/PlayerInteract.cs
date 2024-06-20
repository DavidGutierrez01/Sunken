using Interactables;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private LayerMask _pickupLayer;
        [SerializeField] private float _pickupRange;
        [SerializeField] private Transform _pickupPosition;

        private bool _isHoldingObject;
        private GameObject _currentlyInteractedObject;

        // Update is called once per frame
        private void Update()
        {
            Ray pickupRay = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * _pickupRange, Color.red);

            if (_currentlyInteractedObject != null)
            {
                if (!Input.GetKeyDown(KeyCode.E)) return;

                DropObject(_currentlyInteractedObject);
            }

            if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, _pickupRange, _pickupLayer))
            {
                if (!Input.GetKeyDown(KeyCode.E)) return;

                _currentlyInteractedObject = hitInfo.collider.transform.gameObject;
                InteractWithObject(_currentlyInteractedObject);

                if (!_isHoldingObject)
                {
                    HoldObject(_currentlyInteractedObject);
                }
            }
        }

        private void InteractWithObject(GameObject go)
        {
            if (!go.transform.gameObject.TryGetComponent(out IInteractable interactable)) return;
            interactable.Interact();
        }

        private void HoldObject(GameObject go)
        {
            if (!go.transform.gameObject.TryGetComponent(out IHoldable holdable)) return;

            Physics.IgnoreCollision(go.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
            _isHoldingObject = true;

            go.transform.position = _pickupPosition.transform.position;
            go.transform.parent = _pickupPosition.transform;

            holdable.Hold();
        }

        private void DropObject(GameObject go)
        {
            if (!go.transform.gameObject.TryGetComponent(out IHoldable holdable)) return;

            Physics.IgnoreCollision(go.GetComponent<Collider>(), this.GetComponent<Collider>(), false);
            _isHoldingObject = false;
            go.transform.parent = null;
            _currentlyInteractedObject = null;

            holdable.Drop();
        }
    }
}
