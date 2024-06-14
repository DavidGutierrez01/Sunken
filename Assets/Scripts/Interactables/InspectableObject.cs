using UnityEngine;
using Cinemachine;

namespace Interactables
{
    public class InspectableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCam;
        [SerializeField] private float _rotateSpeed = 2f;

        private void Update()
        {

        }

        public void Interact()
        {
            Debug.Log($"Inspecting {this.transform.name}");
        }
    }
}
