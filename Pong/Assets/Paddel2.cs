using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddel2 : MonoBehaviour
{
    public float speed = 6.0f;
    public float range = 4.0f;

    private Transform ball;

    

    private void Start()
    {
        // Find the ball object
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void FixedUpdate()
    {
        // Move the paddle towards the ball
        Vector2 direction = ball.position - transform.position;
        direction.y = Mathf.Clamp(direction.y, -range, range);
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
