using Interactables;
using UnityEngine;


namespace PlayerScripts
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private LayerMask _pickupLayer;
        [SerializeField] private float _pickupRange;

        // Update is called once per frame
        private void Update()
        {
            Ray pickupRay = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * _pickupRange, Color.red);

            if (!Physics.Raycast(pickupRay, out RaycastHit hitInfo, _pickupRange, _pickupLayer)) return;

            if (!hitInfo.transform.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;

            if (!Input.GetKeyDown(KeyCode.E)) return;

            interactable.Interact();
        }
    }
}
