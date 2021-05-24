using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private CircleCollider2D FruitHitbox;
    [SerializeField] int AttackDamage = 1;
    [SerializeField] float Knockback;
    private GameObject AttackingPlayer;
    private float StartTime;

    void Awake()
    {
        FruitHitbox = GetComponent<CircleCollider2D>();
        FruitHitbox.enabled = true;
        StartTime = Time.time;
    }

    public void SetAttackingPlayer(GameObject Player)
    {
        AttackingPlayer = Player;
    }

    public GameObject GetAttackingPlayer()
    {
        return AttackingPlayer;
    }

    public void DestroyFruit()
    {
        AudioManager.PlaySound("Projectile_Collision3");
        FruitHitbox.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject == AttackingPlayer && Time.time - StartTime < 0.1f)
        {
            return;
        }
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 calculatedKnockback = Knockback * collision.GetContact(0).normal * -1;
            collision.gameObject.GetComponent<PlayerStats>().Damage(AttackDamage, GetAttackingPlayer(), calculatedKnockback);
            DestroyFruit();
        }
        else
        {
            DestroyFruit();
        }
    }

    public static void ApplyFruitKnockback(GameObject playerHit, Vector2 knockback)
    {
        playerHit.GetComponent<Rigidbody2D>().AddForce(knockback); //fruit knockback
    }
}
