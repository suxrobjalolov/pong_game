using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For UI elements

public class PaddleBehavior : MonoBehaviour
{
    public bool SinglePlayer = true; // Default to SinglePlayer
    public float autoMoveSpeed = 10f; // Speed at which the AI paddle moves
    public float playerMoveSpeed = 10f; // Speed for manual movement in MultiPlayer
    public Transform ball; // Reference to the ball

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private float boundary =12f; // Prevent the paddle from moving off-screen

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

    }

    void Update()
    {
        if (SinglePlayer)
        {
            // Automatic paddle control in SinglePlayer mode
            AutoMovePaddle();
        }
        else
        {
            // Manual control for MultiPlayer mode
            ManualMovePaddle();
        }
    }

    void AutoMovePaddle()
    {
        // Check if the ball is on the side of the paddle
        if (ball.position.x > 0) // Assuming this script is attached to the right paddle
        {
            // Random chance of missing the ball (20% chance to miss)
            float missChance = Random.Range(0f, 1f);
            if (missChance < 0.2f)
            {
                // Intentionally miss by doing nothing
                return;
            }

            // Move the paddle towards the ball's y position
            Vector2 targetPosition = new Vector2(transform.position.x, ball.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, autoMoveSpeed * Time.deltaTime);
        }

        // Prevent the paddle from going out of bounds
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        transform.position = pos;
    }

    void ManualMovePaddle()
    {
        // Get player input from numpad 8 and 2 for vertical movement
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.Keypad8))
        {
            verticalInput = 1f; // Move up
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            verticalInput = -1f; // Move down
        }

        // Move the paddle up or down
        transform.Translate(Vector2.up * verticalInput * playerMoveSpeed * Time.deltaTime);

        // Prevent the paddle from going out of bounds
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        transform.position = pos;
    }
}
