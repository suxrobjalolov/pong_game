using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public Transform startingPosition;  // Assign the starting position in Unity
    public GameObject[] collisionObjects;  // Assign the objects to collide with in Unity
    public float ballSpeed = 10f;  // Speed of the ball
    private Rigidbody2D rb;
    
    // Reference to the PauseButtonHandler
    public PauseButtonHandler pauseButtonHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall(); // Launch the ball when the game starts
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if pauseButtonHandler is assigned
        if (pauseButtonHandler == null)
        {
            Debug.LogError("PauseButtonHandler reference is not set!");
            return; // Exit the method if it's null
        }

        // Check if the collided object is one of the specified collision objects
        foreach (GameObject obj in collisionObjects)
        {
            if (collision.gameObject == obj)
            {
                // Call the PauseGame method from PauseButtonHandler
                pauseButtonHandler.PauseGame();
                RespawnBall();
                break;
            }
        }
    }

    void RespawnBall()
    {
        // Respawn the ball at the starting position
        transform.position = startingPosition.position;

        // Reset the ball's velocity
        rb.velocity = Vector2.zero;

        // Optionally, launch the ball again after respawn
        LaunchBall();
    }

    void LaunchBall()
    {
        // Launch the ball in a random direction
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(randomDirection, Random.Range(-1f, 1f)).normalized * ballSpeed;
    }
}
