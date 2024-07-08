using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the TMP_Text element
    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0f; // Initialize the timer
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Increment the timer by the time since the last frame
        UpdateTimerUI(); // Update the UI text
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.FloorToInt(elapsedTime); // Convert the elapsed time to seconds
        timerText.text = "Time: " +  seconds.ToString(); // Update the text element
    }
}
