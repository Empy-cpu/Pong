using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 9f;
    public float maxY = 8f;

    private Vector2 direction;
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    private int leftScore = 0;
    private int rightScore = 0;
    void Start()
    {
        // Set the initial direction of the ball
        direction = new Vector2(Random.Range(-1f, 1f), 0).normalized;

        // Start the ball moving in the initial direction
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void Update()
    {
        // Move the ball in the current direction
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Clamp the ball's position to the screen bounds
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
        pos.y = Mathf.Clamp(pos.y, -maxY, maxY);
        transform.position = pos;

        if ( this.gameObject.transform.position.x == -9f || this.gameObject.transform.position.x == 9f || this.gameObject.transform.position.y == 9f || this.gameObject.transform.position.x == -9f)
        {
            Debug.Log("game over");
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            hitBall();
            rightScore++;
            scoreText1.text = leftScore.ToString();
            
        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            hitBall();
            leftScore++;
            scoreText2.text = rightScore.ToString();

        }
    }

    public void hitBall()
    {
        Debug.Log("hit");
        // Reverse the X direction of the ball and add some randomness to the Y direction
        direction.x = -direction.x;
        direction.y += Random.Range(-0.2f, 0.2f);
        direction = direction.normalized;
    }
  
}
