using UnityEngine;
using UnityEngine.UI;

public class WallCollisionCounter : MonoBehaviour
{
    public Text collisionText; // Reference to the UI Text component
    private int collisionCount = 0; // Track the number of collisions

    // This method will be called when a collision happens
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding with the wall is tagged as "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            collisionCount++; // Increment the collision count
            UpdateCollisionText(); // Update the UI text
        }
    }

    // Update the UI Text with the current collision count
    private void UpdateCollisionText()
    {
        collisionText.text = "" + collisionCount.ToString();
    }
}
