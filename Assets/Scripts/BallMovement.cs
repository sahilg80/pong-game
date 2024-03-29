using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D _rigidBody2D;
    PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.ballMovement = this;
        pv = GetComponent<PhotonView>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        ResetPosition();
        StartingForce();
    }

    public void ResetPosition()
    {
        if (pv.IsMine)
        {
            _rigidBody2D.position = Vector2.zero;
            _rigidBody2D.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartingForce()
    {
        if (pv.IsMine)
        {
            float x = Random.value < 0.5 ? -1f : 1f;
            float y = Random.value < 0.5f ? Random.Range(0.5f, 1f) : Random.Range(-1f, -0.5f);
            Vector2 dir = new Vector2(x, y);
            ApplyForce(dir * 300);
        }
    }

    public void ApplyForce(Vector2 forceDir)
    {
        //print("force dir "+forceDir);
        _rigidBody2D.AddForce(forceDir);
    }
}
