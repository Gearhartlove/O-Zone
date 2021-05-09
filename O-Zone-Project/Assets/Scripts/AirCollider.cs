using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(true);
        }
        else if (collision.tag == "Projectile") { }

        collision.attachedRigidbody.gravityScale = 4.5f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(false);
            collision.attachedRigidbody.gravityScale = 0;
        }
        else if (collision.tag == "Projectile") {
            collision.attachedRigidbody.gravityScale = 0.3f;
        }
    }
}
