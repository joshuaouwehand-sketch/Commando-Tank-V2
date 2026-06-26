using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    { 
        if (target == null)
        {
            return;
        }
        // Follow the player's position
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // Force rotation to always be zero
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

       
    }
}
