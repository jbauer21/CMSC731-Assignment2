using UnityEngine;
using UnityEngine.InputSystem; // Add this!

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float fastMoveFactor = 3f;
    
    [Header("Rotation Settings")]
    public float lookSensitivity = 0.1f; // New system uses raw pixels, so lower this
    public bool invertY = false;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        _rotationX = rot.y;
        _rotationY = rot.x;
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void HandleRotation()
    {
        // New Input System way to get mouse delta
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * lookSensitivity;
        float mouseY = mouseDelta.y * lookSensitivity;

        _rotationX += mouseX;
        _rotationY += invertY ? mouseY : -mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_rotationY, _rotationX, 0f);
    }

    void HandleMovement()
    {
        float currentSpeed = moveSpeed;

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed *= fastMoveFactor;
        }

        // Get WASD input
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        
        Vector3 direction = (transform.forward * moveInput.y) + (transform.right * moveInput.x);
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}