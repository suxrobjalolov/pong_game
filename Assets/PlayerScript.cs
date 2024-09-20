using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 4.5f;  // Prevent paddles from going off the screen

    void Update()
    {
        // Get vertical input from the player
        float verticalInput = Input.GetAxis("Vertical");

        // Move the paddle up or down
        transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);

        // Prevent the paddle from going out of bounds
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        transform.position = pos;
    }
}
