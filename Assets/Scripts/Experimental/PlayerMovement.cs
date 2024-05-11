using UnityEngine;


namespace Experimental
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float _speed;

        #region  private variables  
        private Rigidbody _rigidBody;

        #endregion

        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {
            Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _rigidBody.MovePosition(transform.position + movementInput * Time.deltaTime * _speed);
        }

    }
}