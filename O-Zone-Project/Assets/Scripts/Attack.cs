using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D Hitbox;
    private PlayerCombat Combat;
    private PlayerStats Stats;

    [SerializeField] int AttackDamage = 1;
    [SerializeField] float Knockback;

    private void Awake()
    {
        Hitbox = GetComponent<BoxCollider2D>();
        Combat = GetComponentInParent<PlayerCombat>();
        Stats = GetComponentInParent<PlayerStats>();
    }

    private void Update()
    {
        if (Combat.GetIsAttacking() && !Stats.GetInAir)
        {
            // MELEE ATTACK
            Hitbox.enabled = true;
        } else
        {
            Hitbox.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 calculatedKnockback = Knockback * transform.up;
            collision.GetComponent<PlayerStats>().Damage(AttackDamage, transform.parent.gameObject, calculatedKnockback);
        } else if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Fruit>().DestroyFruit();
        }
    }
}
