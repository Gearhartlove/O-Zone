using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D Hitbox;
    private PlayerCombat Combat;
    private PlayerStats Stats;

    [SerializeField] int AttackDamage = 1;

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
            GetComponent<Animator>().SetTrigger("Activate");
        } else
        {
            Hitbox.enabled = false;
            if (Combat.GetIsAttacking() && Stats.GetInAir)
            {
                // RANGED ATTACK

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().Damage(AttackDamage);
        } else if (collision.CompareTag("Projectile"))
        {
            // Destroy fruit
        }
    }
}
