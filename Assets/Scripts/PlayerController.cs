using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 50f;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private InputActionReference movementControls;
    [SerializeField] private InputActionReference lookControls;

    private Rigidbody rb;

    private Transform orientation;

    private float xRotation;
    private float yRotation;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 look = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; ;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        var moveInput = movementControls.action.ReadValue<Vector3>();
        moveDirection = (moveInput.z * transform.forward) + (moveInput.x * transform.right) + new Vector3(0, moveInput.y, 0);

        look = lookControls.action.ReadValue<Vector2>() * Time.deltaTime * lookSensitivity;

        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += look.x;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
