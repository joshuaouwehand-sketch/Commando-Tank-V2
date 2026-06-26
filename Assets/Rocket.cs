using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 18f;
    public int damage = 14;
    public AudioManager audioManager;
    private Rigidbody2D rb;
    private Transform player;
    public AudioClip Rocketsound;
    void Start()
    {

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();

        player =
            GameObject
            .FindGameObjectWithTag("Player")
            .transform;

        // Aim once at player
        Vector2 direction =
            (
                player.position
                - transform.position
            ).normalized;

        rb.linearVelocity =
            direction * speed;

        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(
        Collision2D collision
    )
    {
        if (
            collision.gameObject
            .CompareTag("Boss")
        )
            return;

        TankHealth health =
            collision
            .gameObject
            .GetComponent<TankHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
            audioManager.PlaySound(Rocketsound);
        }

        Destroy(gameObject);
    }
}