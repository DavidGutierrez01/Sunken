using UnityEngine;

namespace Prompts
{
    public class Billboarding : MonoBehaviour
    {
        private Camera _camera;
        Vector3 _cameraDirection;

        private void Awake()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            _cameraDirection = _camera.transform.forward;

            transform.rotation = Quaternion.LookRotation(_cameraDirection);
        }
    }
}
