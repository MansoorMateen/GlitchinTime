using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialMenuUI;

    private bool isPaused = true;

    void Start()
    {
        // Start the game paused
        Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        tutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        tutorialMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
