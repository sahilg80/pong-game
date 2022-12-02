using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    // [SerializeField]
    // GameObject ball;
    [SerializeField]
    float strength;
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
            // print("opppp");
            BallMovement ballMovement = collision.gameObject.GetComponent<BallMovement>();
            ballMovement.ApplyForce(-collision.GetContact(0).normal * strength);
        }
    }
    

}
