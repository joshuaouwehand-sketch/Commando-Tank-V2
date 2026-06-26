using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;

    void Start()
    {
        // Pause game while menu is open
        Time.timeScale = 0f;
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);

        // Resume game
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}