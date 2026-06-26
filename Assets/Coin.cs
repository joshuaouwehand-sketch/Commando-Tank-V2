using System.Security.Cryptography;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioManager audioManager;
    public GameManager gameManager;

    public AudioClip coinsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           audioManager.PlaySound(coinsound);

            Destroy(gameObject);
            GameManager.coins += 1;
        }
    }








}
