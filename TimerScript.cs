using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For restarting the game

public class TimerScript : MonoBehaviour
{
    public Text timerText;  // Drag and drop the Text UI element here
    public float timeRemaining = 40f;
    public int lives = 3;   // Total player lives
    public Transform respawnPoint;  // Reference to the respawn location
    public GameObject gameOverPanel;  // Drag and drop the Game Over UI panel here

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString() + "s";
        }
        else
        {
            HandleTimerExpiry();
        }
    }

    void HandleTimerExpiry()
    {
        lives--;
        if (lives > 0)
        {
            // Respawn player and reset timer
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = respawnPoint.position;
            timeRemaining = 40f;
        }
        else
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        // Activate Game Over UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;  // Pause the game
    }

    public void RestartGame()
    {
        // Reset time scale and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload current scene
    }
}
