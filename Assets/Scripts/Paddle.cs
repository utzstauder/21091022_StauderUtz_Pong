using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public string inputAxisName = "Horizontal";
    public float speed = 2;

    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(rigidbody2D);
    }

    void Update()
    {
        // transform.position += Vector3.up * speed * Time.deltaTime * Input.GetAxisRaw(inputAxisName);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector3.up * speed * Input.GetAxisRaw(inputAxisName);
    }
}
