using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    Rigidbody2D _rigidBody2D;
    Rigidbody2D _ballRigidBody2D;
    
    [SerializeField]
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _ballRigidBody2D = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (_ballRigidBody2D.velocity.x > 0)
        {
            if (ball.transform.position.y > transform.position.y)
            {
                _rigidBody2D.AddForce(Vector2.up * paddleSpeed);
            }
            else
            {
                _rigidBody2D.AddForce(Vector2.down * paddleSpeed);
            }
        }
        else
        {
            if (transform.position.y<0)
            {
                _rigidBody2D.AddForce(Vector2.up * paddleSpeed);
            }
            else
            {
                _rigidBody2D.AddForce(Vector2.down * paddleSpeed);
            }
        }
    }

}
