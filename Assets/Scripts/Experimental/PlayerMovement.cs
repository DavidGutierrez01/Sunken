using UnityEngine;


namespace Experimental
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        #region Components  
        public Rigidbody RigidBody { get; private set; }

        #endregion

        void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {
            Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            RigidBody.MovePosition(transform.position + movementInput * Time.deltaTime * _speed);
        }

    }
}