using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public AudioSource music;
    public GameObject Door;
    public AudioManager audioManager;
    public AudioClip Metaldoorslami;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {

            music.Stop();

            Door.SetActive(true);
            audioManager.PlaySound(Metaldoorslami);
            Destroy(gameObject);
        }
    }
}
