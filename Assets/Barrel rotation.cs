using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float rotationSpeed = 200f;
    public Rigidbody2D rigidbody2D;

    InputAction moveaction;
    InputAction lookaction;

    private void Start()
    {
        moveaction = InputSystem.actions.FindAction("Move");
        lookaction = InputSystem.actions.FindAction("Look");
    }

    void FixedUpdate()
    {
        // Input ophalen
        Vector2 moveInput = moveaction.ReadValue<Vector2>();
        Vector2 lookInput = lookaction.ReadValue<Vector2>();

        // Bewegen in wereldruimte
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);
        rigidbody2D.linearVelocity = movement * moveSpeed * Time.deltaTime;

        // Alleen links/rechts draaien met rechter joystick
        float rotateAmount = -lookInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotateAmount);
    }
}