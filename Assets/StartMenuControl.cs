using UnityEngine;
using UnityEngine.UI; // For UI elements

public class StartMenuHandler : MonoBehaviour
{
    public GameObject startMenu; // Assign the start menu panel in Unity
    public GameObject gameUI; // Assign the main game UI in Unity
    public PaddleBehavior paddleBehavior; // Reference to the PaddleBehavior script
    public PauseButtonHandler pauseButtonHandler; // Reference to the PauseButtonHandler

    void Start()
    {
        startMenu.SetActive(true);
        gameUI.SetActive(false); // Hide game UI at the start
        
        // Set time scale to 0 to start the game
        Time.timeScale = 0;
    }

    public void StartSinglePlayer()
    {
        paddleBehavior.SinglePlayer = true; // Set mode to Single Player
        StartGame();
    }

    public void StartMultiplayer()
    {
        paddleBehavior.SinglePlayer = false; // Set mode to Multiplayer
        StartGame();
    }

    private void StartGame()
    {
        startMenu.SetActive(false);
        gameUI.SetActive(true);
        
        // Optionally, you can call any initialization methods needed for the game
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
