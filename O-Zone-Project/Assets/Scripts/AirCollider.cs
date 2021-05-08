using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(true);
        }

        collision.attachedRigidbody.gravityScale = 5;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(false);
        }

        collision.attachedRigidbody.gravityScale = 0;
    }
}
