using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurret : MonoBehaviour
{
    InputAction lookAction;

    float storedAngle = 0f;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");

        // Start at current angle
        storedAngle = transform.eulerAngles.z;
    }

    void LateUpdate()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        // Only change target when stick moves
        if (lookInput.sqrMagnitude > 0.1f)
        {
            storedAngle =
                Mathf.Atan2(lookInput.y, lookInput.x)
                * Mathf.Rad2Deg
                - 90f;
        }

        // Keep applying stored world angle
        transform.rotation =
            Quaternion.Euler(0, 0, storedAngle);
    }
}