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
            //Debug.Log("Set In Air");
            if (Mathf.Abs(collision.attachedRigidbody.velocity.y) > 1.5f)
            {
                Vector3 ParticlePosition = collision.transform.position;
                GameObject particles = Instantiate(WaterParticles, ParticlePosition, Quaternion.Euler(0, 1, 0));
                ParticleSystem.MainModule mainModule = particles.GetComponent<ParticleSystem>().main;
                mainModule.startSpeed = Mathf.Abs(collision.attachedRigidbody.velocity.y) * 1.5f;
            }
        }
        else if (collision.tag == "Projectile") { }

        if (collision.tag == "Player" || collision.tag == "Projectile")
        {
            collision.attachedRigidbody.gravityScale = 4.5f;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerStats>().SetInAir(false);
            //Debug.Log("Set In Water");
            collision.attachedRigidbody.gravityScale = 0;
        }
        else if (collision.tag == "Projectile") {
            collision.attachedRigidbody.gravityScale = 0.3f;
        }
        if (collision.attachedRigidbody && Mathf.Abs(collision.attachedRigidbody.velocity.y) > 1.5f)
        {
            Vector3 ParticlePosition = collision.transform.position;
            GameObject particles = Instantiate(WaterParticles, ParticlePosition, Quaternion.Euler(0, 1, 0));
            ParticleSystem.MainModule mainModule = particles.GetComponent<ParticleSystem>().main;
            mainModule.startSpeed = Mathf.Abs(collision.attachedRigidbody.velocity.y) * 1.5f;
        }
    }
}
