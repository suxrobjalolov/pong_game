using UnityEngine;
using UnityEngine.UI;

public class PauseButtonHandler : MonoBehaviour
{
    public Text buttonText;  // Reference to the Text component of the button
    private bool isPaused = true;  // Start in paused state
    public PauseMenuHandler pauseMenuHandler;  // Reference to PauseMenuHandler

    void Start()
    {
        Debug.Log("Game Started in Paused state");
        Time.timeScale = 0;  // Game is paused at start
        buttonText.text = "Play";  // Initial text
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0;
        buttonText.text = "Play";
        isPaused = true;
        pauseMenuHandler.ShowPauseMenu();  // Show the pause menu
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game");
        Time.timeScale = 1;
        buttonText.text = "Pause";
        isPaused = false;
        pauseMenuHandler.HidePauseMenu();  // Hide the pause menu
    }
}
