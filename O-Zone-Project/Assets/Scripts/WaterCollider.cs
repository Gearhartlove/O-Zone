using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInWater(true);
        }

        collision.attachedRigidbody.gravityScale = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInWater(false);
        }

        collision.attachedRigidbody.gravityScale = 1;
    }
}
