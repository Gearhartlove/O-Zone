using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [SerializeField] GameObject DeathParticles;
    [SerializeField] Camera MainCamera;

    private GameObject RecentDeathParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().Damage(1000);

            Vector3 DeathParticlePosition = collision.transform.position;
            Vector3 CameraCenter = MainCamera.transform.position;
            Vector3 collisionPosition = collision.transform.position;
            float DeathParticleRotation = Vector3.Angle(collisionPosition, CameraCenter);
            Quaternion DeathParticleQuaternion = Quaternion.Euler(0, 0, DeathParticleRotation);
            RecentDeathParticles = Instantiate(DeathParticles, collision.transform.position, DeathParticleQuaternion);
            if (RecentDeathParticles.transform.position.x < 0)
            {
                RecentDeathParticles.transform.up = Vector3.right;
            } else
            {
                RecentDeathParticles.transform.up = Vector3.left;
            }
        } else if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Fruit>().DestroyFruit();
        }
    }
}
