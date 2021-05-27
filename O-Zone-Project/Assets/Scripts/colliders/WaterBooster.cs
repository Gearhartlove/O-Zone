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

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D collisionRigidbody = collision.attachedRigidbody;
        if (collisionRigidbody)
        {
            Vector2 appliedBoost = new Vector2(Mathf.Clamp(collisionRigidbody.velocity.x * boostVector.x, -350, 350), boostVector.y * collisionRigidbody.velocity.y);
            if (collisionRigidbody.velocity.y > minVelocity)
            {
                collisionRigidbody.AddForce(appliedBoost);
            } else if (collisionRigidbody.velocity.y < -minVelocity)
            {
                collisionRigidbody.AddForce(-appliedBoost / 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D collisionRigidbody = collision.attachedRigidbody;
        if (collisionRigidbody)
        {
            if (collisionRigidbody.velocity.y > minVelocity)
            {
                AudioManager.PlaySound("OzoneSplashUp");
            }
            else if (collisionRigidbody.velocity.y < -minVelocity)
            {
                AudioManager.PlaySound("OzoneSplashDown");
            }
        }
    }
}
