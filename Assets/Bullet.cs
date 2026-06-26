using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;
    public int damage = 10;

    void Start()
    {
       
        Destroy(gameObject, lifeTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.right * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Shop"))
        {
            Destroy(gameObject);
        }
     
        if (collision.gameObject.CompareTag("Tank"))
        {
            
            // Optional: Access tank's health script
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damage);
            }

            // Destroy bullet after hitting
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {

            // Optional: Access tank's health script
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damage);
            }

            // Destroy bullet after hitting
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {

            // Optional: Access tank's health script
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damage);
            }

            // Destroy bullet after hitting
            Destroy(gameObject);
        }
    }

}
