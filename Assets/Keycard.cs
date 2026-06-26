using UnityEngine;

public class Keycard : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip keycardsound;
    public GameObject Door;
    private Vector3 spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            audioManager.PlaySound(keycardsound);

           gameObject.SetActive(false);
            Door.SetActive(false);
            
        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);

        transform.position = spawnPosition;

        Door.SetActive(true);


    }
}
