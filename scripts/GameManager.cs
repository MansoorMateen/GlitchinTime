using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Unpause the game
        pauseMenuUI.SetActive(false); // Hide the pause menu
        isPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        pauseMenuUI.SetActive(true); // Show the pause menu
        isPaused = true;
    }
}