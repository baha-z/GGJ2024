using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include the TextMeshPro namespace

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 60f; // Set your time limit for the level in seconds
    public TextMeshProUGUI timerText; // Assign a TextMeshProUGUI element in the Inspector

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        // Initialize the timer
        timeRemaining = timeLimit;
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                // Decrease the remaining time and update the display
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                Debug.Log("Time's Up!");
                timeRemaining = 0;
                timerRunning = false;
                OnTimeUp(); // Call the method that handles the end of the timer
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        // Format and display the remaining time. Adjust the formatting as needed.
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimeUp()
    {
        SceneManager.LoadScene("SampleScene");

        // Handle what happens when the time is up
        // For example, end the level or fail the player
    }
}
