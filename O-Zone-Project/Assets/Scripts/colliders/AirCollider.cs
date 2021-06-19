using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCollider : MonoBehaviour
{
    [SerializeField] private GameObject WaterParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(true);
            if (Mathf.Abs(collision.attachedRigidbody.velocity.y) > 1.5f)
            {
                Vector3 ParticlePosition = collision.transform.position;
                ContactPoint2D[] contacts = new ContactPoint2D[1];
                collision.GetContacts(contacts);
                Quaternion CollisionNormal = Quaternion.Euler(contacts[0].normal);
                GameObject particles = Instantiate(WaterParticles, ParticlePosition, CollisionNormal);
                ParticleSystem.MainModule mainModule = particles.GetComponent<ParticleSystem>().main;
                mainModule.startSpeed = Mathf.Abs(collision.attachedRigidbody.velocity.y) * 1.5f;
            }
        }
        else if (collision.tag == "Projectile") { }

        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.attachedRigidbody.gravityScale = 4.5f;
            collision.gameObject.layer = 3;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(false);
            collision.attachedRigidbody.gravityScale = 0;
            collision.gameObject.layer = 6;
        }
        else if (collision.tag == "Projectile") {
            collision.attachedRigidbody.gravityScale = 0.3f;
            collision.gameObject.layer = 6;
        }
        if (collision.attachedRigidbody && Mathf.Abs(collision.attachedRigidbody.velocity.y) > 1.5f)
        {
            Vector3 ParticlePosition = collision.transform.position;
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            collision.GetContacts(contacts);
            Quaternion CollisionNormal = Quaternion.Euler(contacts[0].normal);
            GameObject particles = Instantiate(WaterParticles, ParticlePosition, CollisionNormal);
            ParticleSystem.MainModule mainModule = particles.GetComponent<ParticleSystem>().main;
            mainModule.startSpeed = Mathf.Abs(collision.attachedRigidbody.velocity.y) * 1.5f;
        }
    }
}
