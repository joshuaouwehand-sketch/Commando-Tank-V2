using UnityEngine;
using UnityEngine.InputSystem;
public class TankShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    InputAction attackaction;

    public float shootCooldown = 0.2f;

    private float nextShootTime;

    void Update()
    {
        if (Keyboard.current.lKey.isPressed && Time.time > nextShootTime)
        {
            Shoot();

            nextShootTime = Time.time + shootCooldown;
        }
        if (attackaction.WasPressedThisFrame())
            {
            Shoot();

            nextShootTime = Time.time + shootCooldown;
        }

    }
    void Start()
    {
        attackaction = InputSystem.actions.FindAction("attack");
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.damage = GameManager.playerdamage;
        }
    }
}