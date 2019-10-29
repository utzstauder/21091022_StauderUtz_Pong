using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed;

    [Range(1.01f, 1.25f)]
    public float speedMultiplier = 1.01f;

    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            rigidbody2D.velocity *= speedMultiplier;
            Debug.Log(rigidbody2D.velocity.magnitude);
        }

        //// look for Paddle component on colliding GameObject
        //Paddle paddle = collision.gameObject.GetComponent<Paddle>();
        //// Debug.Log(paddle);
        //if (paddle != null)
        //{
        //    rigidbody2D.velocity *= speedMultiplier;
        //    Debug.Log(rigidbody2D.velocity.magnitude);
        //}
    }

    private void ResetBall()
    {
        // reset ball position
        transform.position = Vector3.zero;

        // set initial speed
        rigidbody2D.velocity = initialSpeed * Random.insideUnitCircle.normalized;
    }
}
