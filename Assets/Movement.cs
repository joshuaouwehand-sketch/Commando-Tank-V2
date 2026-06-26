using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    InputAction moveAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Move directly with left stick
        rb.linearVelocity = moveInput * moveSpeed;

        // Rotate tank to face movement direction
        if (moveInput.sqrMagnitude > 0.01f)
        {
            float angle =
                Mathf.Atan2(moveInput.y, moveInput.x)
                * Mathf.Rad2Deg
                - 90f;

            rb.MoveRotation(angle);
        }
    }
}