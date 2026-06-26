using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip checkpointsound;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            audioManager.PlaySound(checkpointsound);
            GameManager.instance.SetCheckpoint(
                other.transform.position
            );

            Destroy(gameObject); // remove checkpoint object
        }
    }
}