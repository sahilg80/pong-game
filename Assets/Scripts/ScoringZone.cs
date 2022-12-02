using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoringZone : MonoBehaviour
{
    public static event Action<string> OnCollisionWithWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //print("opppp");
            OnCollisionWithWall?.Invoke(this.gameObject.name);
            // BallMovement ballMovement = collision.gameObject.GetComponent<BallMovement>();
            // ballMovement.ApplyForce(-collision.GetContact(0).normal * strength);
        }
    }
}
