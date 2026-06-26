using UnityEngine;

public class Treasure : MonoBehaviour
{



    
    public AudioManager audioManager;
    public GameManager gameManager;

    public AudioClip winsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySound(winsound);
            gameManager.Winning();
            Destroy(gameObject);
            
        }
    }








}

