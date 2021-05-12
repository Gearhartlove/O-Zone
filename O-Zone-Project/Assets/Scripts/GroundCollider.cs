using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats PS =
            collision.gameObject.GetComponent<PlayerStats>();
        Rigidbody2D RB =
            collision.gameObject.GetComponent<Rigidbody2D>();
        if (PS.GetInAir && RB.velocity.magnitude > Mathf.Epsilon)
        {
            PS.Damage(1000);
        }
    }
}
