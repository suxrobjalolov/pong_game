using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10f;  // Constant speed of the ball
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // Make this method public so that other scripts can call it
    public void LaunchBall()
    {
        // Launch the ball in a random direction
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(randomDirection, Random.Range(-1f, 1f)).normalized * ballSpeed;
    }

    void FixedUpdate()
    {
        // Keep ball velocity constant
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflecting the ball on contact should be handled automatically by the physics system
        // with colliders and the bouncy physics material.
    }
}
