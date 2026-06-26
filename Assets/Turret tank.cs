using UnityEngine;

public class Turrettank : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float idleSpinSpeed = 50f;

    [Header("Detection Settings")]
    public float detectionRadius = 6f;
    private Transform player;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;

    private float fireTimer;
    private Rigidbody2D rb;
    private Vector3 spawnPosition;
    private float spawnRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;

        fireTimer = fireRate;

        // Save spawn data
        spawnPosition = transform.position;
        spawnRotation = rb.rotation;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            LookAtPlayer();
        }
        else
        {
            SpinIdle();
        }

        HandleShooting();
    }

    void SpinIdle()
    {
        // Rotate constantly
        rb.rotation += idleSpinSpeed * Time.deltaTime;
    }

    void LookAtPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rb.rotation = angle - 90f;
    }

    void HandleShooting()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    public void Respawn()
    {
        gameObject.SetActive(true);

        transform.position = spawnPosition;

        rb.linearVelocity = Vector2.zero;
        rb.rotation = spawnRotation;

        fireTimer = fireRate;
        GetComponent<TankHealth>()?.ResetHealth();
    }

}
