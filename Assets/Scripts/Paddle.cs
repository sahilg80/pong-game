using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    protected float paddleSpeed;
    protected Rigidbody2D rigidBody2D;
    void Awake(){
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    public void ResetPosition(){
        rigidBody2D.velocity = Vector2.zero;
        rigidBody2D.position = new Vector2(rigidBody2D.position.x, 0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
