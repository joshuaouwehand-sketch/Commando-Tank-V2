using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip extralifesound;
    public TankHealth playerHealth;
    //tank health script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            TankHealth tankHealth = GameObject.FindGameObjectWithTag("Player")
                                  .GetComponent<TankHealth>();
            audioManager.PlaySound(extralifesound);
            tankHealth.Lives += 1;
            Destroy(gameObject);
            
        }
    }

}
