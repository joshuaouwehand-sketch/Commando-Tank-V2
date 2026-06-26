using UnityEngine;

public class BossTank : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 4f;
    public float moveDistance = 6f;

    [Header("Combat")]
    public Transform firePoint;
    public GameObject rocketPrefab;

    public float fireRate = 1.5f;
    public float rocketSpeed = 14f;

    private float fireTimer;

    private Transform player;
    private Vector3 startPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        startPos = transform.position;

        fireTimer = fireRate;
    }

    void Update()
    {
        if (player == null) return;

        MoveSideways();

        AimAtPlayer();

        HandleShooting();
    }

    void MoveSideways()
    {
        float x =
            Mathf.Sin(Time.time * moveSpeed)
            * moveDistance;

        transform.position =
            new Vector3(
                startPos.x + x,
                transform.position.y,
                transform.position.z
            );
    }

    void AimAtPlayer()
    {
        Vector2 direction =
            player.position
            - transform.position;

        float angle =
            Mathf.Atan2(
                direction.y,
                direction.x
            ) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(
                0,
                0,
                angle - 90
            );
    }

    void HandleShooting()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            Shoot();

            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        GameObject rocket =
            Instantiate(
                rocketPrefab,
                firePoint.position,
                firePoint.rotation
            );

        Rigidbody2D rb =
            rocket.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity =
                firePoint.up
                * rocketSpeed;
        }
    }
}