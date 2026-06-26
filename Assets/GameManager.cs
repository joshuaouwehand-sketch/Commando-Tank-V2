using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int coins = 0;
    public static int playerdamage = 10;
    public GameObject Winpanel;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI lives;
    private bool Winon;
    InputAction attackaction;
    public GameObject WInUI;
    public bool GameOver = false;
    private EnemyAi[] enemies;
    private Turrettank[] turrets;
    private Healthup[] healthpack;
    public MonoBehaviour movementscript;
    public GameObject firstSelected;
    public GameObject firstSelectedmenu;
    // Save checkpoint
    public bool checkpointActive = false;
    public Vector3 checkpointPosition;
    private Keycard[] keycards;
    public GameObject MainMenupanel;
    void Start()
    {

        enemies = FindObjectsByType<EnemyAi>(
    FindObjectsInactive.Include,
    FindObjectsSortMode.None
);

        turrets = FindObjectsByType<Turrettank>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );
        healthpack = FindObjectsByType<Healthup>(
    FindObjectsInactive.Include,
    FindObjectsSortMode.None


);
        keycards = FindObjectsByType<Keycard>(
    FindObjectsInactive.Include,
    FindObjectsSortMode.None
);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

        }

        attackaction = InputSystem.actions.FindAction("attack");

        SceneManager.sceneLoaded += OnSceneLoaded;
        Winpanel.SetActive(false);
        Winon = false;
        MainMenu();
    }

    void Update()
    {
        cointext.text = coins.ToString();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            TankHealth health = player.GetComponent<TankHealth>();

            if (health != null)
            {
                lives.text = health.Lives.ToString();
            }
        }

        if (GameOver &&
            attackaction != null &&
            attackaction.WasPressedThisFrame())
        {
            RestartGame();
        }
       
    }


    public void SetCheckpoint(Vector3 pos)
    {
        checkpointActive = true;
        checkpointPosition = pos;

        Debug.Log("Checkpoint saved at: " + pos);
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (checkpointActive)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                player.transform.position = checkpointPosition;
            }
        }
    }
    public void RespawnEnemies()
    {
        foreach (EnemyAi enemy in enemies)
        {
            if (enemy != null)
                enemy.Respawn();
        }

        foreach (Turrettank turret in turrets)
        {
            if (turret != null)
                turret.Respawn();
        }
        foreach (Healthup healthup in healthpack)
        {
            if (healthup != null)
                healthup.Respawn();
        }
        foreach (Keycard keycard in keycards)
        {
            if (keycard != null)
                keycard.Respawn();
        }
    }
    public void RestartGame()
    {
        coins = 0;
        playerdamage = 10;

        GameOver = false;

        checkpointActive = false;
        checkpointPosition = Vector3.zero;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            TankMovement movement = player.GetComponent<TankMovement>();
            TankHealth health = player.GetComponent<TankHealth>();

            if (movement != null)
                movement.moveSpeed = 200f;

            if (health != null)
                health.Lives = 5;
        }

        SceneManager.LoadScene(0);
    }
    public void Winning()
    {
        Winpanel.SetActive(true);
        WInUI.SetActive(true);

        movementscript.enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);

        Winon = true;
    }
    public void MainMenu() { 
        MainMenupanel.SetActive(true);
        movementscript.enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedmenu);
        Time.timeScale = 0f;
    }
    public void Startgame() { 
        MainMenupanel.SetActive(false);
        movementscript.enabled=true;
        Time.timeScale = 1f;
        AudioSource music = GetComponent<AudioSource>();

        if (music != null && !music.isPlaying)
        {
            music.loop = true;
            music.Play();
        }


    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
    



