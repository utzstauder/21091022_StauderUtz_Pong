using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed;

    [Range(1.01f, 1.25f)]
    public float speedMultiplier = 1.01f;
    [Range(0, 3f)]
    public float deviationFactor = 2;

    Rigidbody2D rigidbody2D;
    GameController gameController;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.OnGameStateChanged += GameController_OnGameStateChanged;
        }
    }

    private void GameController_OnGameStateChanged(bool playing)
    {
        Debug.Log(gameObject.name + ": event received");
        if (playing)
        {
            StartBall();
        } else
        {
            ResetBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 ballPos = transform.position;
            Vector3 paddlePos = collision.transform.position;

            float deltaPos = ballPos.y - paddlePos.y;
            if (deltaPos > 0)
            {
                deltaPos -= collision.otherCollider.bounds.extents.y;
            }
            else if (deltaPos < 0)
            {
                deltaPos -= collision.otherCollider.bounds.extents.y;
            }
            // Debug.Log("deltaPos: " + deltaPos);

            float paddleWidth = collision.transform.localScale.x * collision.collider.bounds.size.x;
            // Debug.Log("paddleWidth: " + paddleWidth);

            float normalizedDeltaPos = deltaPos / paddleWidth;
            // Debug.Log("normalizedDeltaPos: " + normalizedDeltaPos);

            float vTemp = rigidbody2D.velocity.magnitude;

            float newY = rigidbody2D.velocity.y;
            newY += normalizedDeltaPos * deviationFactor;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, newY);

            rigidbody2D.velocity = rigidbody2D.velocity.normalized * vTemp;

            rigidbody2D.velocity *= speedMultiplier;
            // Debug.Log("velocity: " + rigidbody2D.velocity.magnitude);
        }else
        {
            // TODO: fix vertical ball bounce
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            ResetBall();
            StartBall();
        }
    }

    private void ResetBall()
    {
        // reset ball position
        transform.position = Vector3.zero;

        // remove ball speed
        rigidbody2D.velocity = Vector2.zero;
    }

    void StartBall()
    {
        // set initial speed
        rigidbody2D.velocity = initialSpeed * Random.insideUnitCircle.normalized;
    }
}
