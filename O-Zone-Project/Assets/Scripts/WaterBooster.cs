using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBooster : MonoBehaviour
{
    [SerializeField]
    private float minVelocity;

    [SerializeField]
    private Vector2 boostVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D collisionRigidbody = collision.attachedRigidbody;
        if (collisionRigidbody)
        {
            if (collisionRigidbody.velocity.y > minVelocity)
            {
                collisionRigidbody.AddForce(boostVector);
            } else if (collisionRigidbody.velocity.y < -minVelocity)
            {
                collisionRigidbody.AddRelativeForce(-boostVector);
            }
        }
    }
}
