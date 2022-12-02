using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerPaddle : Paddle
{
    Vector2 dir;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            if (Input.GetAxis("Vertical") > 0)
            {
                dir = Vector2.up;
                // rigidBody2D.AddForce(Vector2.up * paddleSpeed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                dir = Vector2.down;
                // rigidBody2D.AddForce(Vector2.down * paddleSpeed);
            }
            else
            {
                dir = Vector2.zero;
            }
        }
    }
    void FixedUpdate()
    {
        rigidBody2D.AddForce(dir * paddleSpeed);
    }
}
