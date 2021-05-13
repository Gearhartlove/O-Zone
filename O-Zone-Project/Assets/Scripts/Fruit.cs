using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private CircleCollider2D FruitHitbox;
    [SerializeField] int AttackDamage = 1;
    [SerializeField] float Knockback;
    private GameObject AttackingPlayer;

    void Awake()
    {
        FruitHitbox = GetComponent<CircleCollider2D>();
        FruitHitbox.enabled = true;
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
        AudioManager.PlaySound("FruitImpact");
        FruitHitbox.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
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
