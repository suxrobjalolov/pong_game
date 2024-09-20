using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenuPanel;        // Reference to the Pause Menu Panel
    public PauseButtonHandler pauseButton;   // Reference to the Pause Button Handler

    private bool isGamePaused = false;       // Track if the game is paused

    void Start()
    {
        // Ensure the pause menu is inactive at the start
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // Check for ESC key press to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton.OnButtonClick();  // Trigger the same logic as pause button
        }
    }

    public void ShowPauseMenu()
    {
        pauseMenuPanel.SetActive(true);
        isGamePaused = true;
    }

    public void HidePauseMenu()
    {
        pauseMenuPanel.SetActive(false);
        isGamePaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload current scene
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Load the main menu scene
    }
}
