using UnityEngine;

public class Bosstrigger : MonoBehaviour
{
    public Camera Camera;
    public Camera MainCamera;

    public GameObject boss;

    public AudioSource bossMusic; // add this
    public GameObject YourHealth;

    void Start()
    {
        Camera.enabled = false;
        MainCamera.enabled = true;
        YourHealth.SetActive(false);
        boss.SetActive(false);

        // ensure music is not playing at start
        if (bossMusic != null)
        {
            bossMusic.Stop();
            bossMusic.loop = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Camera.enabled = true;
            MainCamera.enabled = false;

            boss.SetActive(true);
            YourHealth.SetActive(true);
            // start boss music
            if (bossMusic != null)
            {
                bossMusic.loop = true;
                bossMusic.Play();
            }

            Destroy(gameObject);
        }
    }
}