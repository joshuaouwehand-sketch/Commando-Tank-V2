using UnityEngine;

public class Healthup : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip healthsound;
    private Vector3 spawnPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        spawnPosition = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tank gets health");
            audioManager.PlaySound(healthsound);
            // Optional: Access tank's health script
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.GetHealth(30);
                gameObject.SetActive(false);
            }

            
        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);

        transform.position = spawnPosition;

        

        
    }
}
