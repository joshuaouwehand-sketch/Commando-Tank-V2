using UnityEngine;
using TMPro;
public class EnemyAi : MonoBehaviour

{
    


    [Header("Movement Settings")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    [Header("Detection Settings")]
    public float detectionRadius = 5f;
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fireTimer = fireRate;
        // Save spawn data
        spawnPosition = transform.position;
        spawnRotation = rb.rotation;
        
    }

    void Update()
    {
        if (player == null) return;
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            ChasePlayer();
            HandleShooting();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        // If no patrol points are assigned, stop moving and do nothing
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        rb.linearVelocity = direction * patrolSpeed;

        // Rotate tank to face target point
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * chaseSpeed;

        // Rotate to face player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;
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

    // Optional: visualize detection radius in editor
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

        currentPointIndex = 0;

        fireTimer = fireRate;

        GetComponent<TankHealth>()?.ResetHealth();

    }
}
