
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshPro healthText;
    private Transform player;
    public GameObject GameOverUI;
    public AudioClip bigexplosionsound;
    public AudioClip explosionsound;
    public AudioClip hitsound;
    public GameObject coinPrefab;
    public AudioClip Hugeexpolsion;
    public AudioManager audioManager;
    public bool GameOver = false;
    public int Lives = 5;
    public GameObject Supporter;
    public GameObject Supporter2;
    public TextMeshProUGUI uiHealthText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        UpdateHealthText();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        GameOverUI.SetActive(false);
        GameOver = false;
        


    }
    void LateUpdate()
    {
        // Prevent text from rotating with the tank
        healthText.transform.rotation = Quaternion.identity;

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        UpdateHealthText(); 
        if (currentHealth <= 0)
        {
            if (CompareTag("Player"))
            {
                audioManager.PlaySound(bigexplosionsound);
                Lives -= 1;

                if (Lives < 1)
                {
                   Lives = 0;
                    GameOverUI.SetActive(true);
                GameManager.instance.GameOver = true;
                    Destroy(gameObject);
                }
                else
                {
                    // repawn player at checkpoint or start position
                    
                    transform.position = new Vector3(-2.64f, 0.09f, 0.0f);
                        transform.position = GameManager.instance.checkpointPosition;
                    // reset health
                    currentHealth = maxHealth;
                    UpdateHealthText();
                    GameManager.instance.RespawnEnemies();
                }



            }
            if (CompareTag("Tank"))
            {
                audioManager.PlaySound(explosionsound);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                
            }
            if (CompareTag("Boss"))
            {
                audioManager.PlaySound(Hugeexpolsion);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                Destroy(Supporter);
                Destroy(Supporter2);
                gameObject.SetActive(false);
                
            }


        }
        else
        {
            audioManager.PlaySound(hitsound);
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
        if (uiHealthText != null)
        {
            uiHealthText.text = currentHealth.ToString();
        }
    }
    void UpdateLivesText()
    {
        // Update the lives text in the UI
        GameManager.instance.lives.text = Lives.ToString();
    }

    public void GetHealth(int amount)
    {
        

        currentHealth += amount;

        // Zorg dat health niet boven maxHealth gaat
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthText();
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;

        UpdateHealthText();

    }
}
