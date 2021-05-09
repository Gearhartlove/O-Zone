using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player.PlayerComponents;

public class PlayerCombat : MonoBehaviour
{
    private bool IsAttacking = false;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Fruit;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float ProjectileSpeed;
    private float StoredSpeed;

    private GameObject NewExplosion;

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (GetPStats.GetAttackCooldown) // If on cooldown, exits the function immediately
        {
            return;
        }
        GetPAnimator.SetTrigger("Attack");
        GetPStats.SetAttackCooldown(true);
        StoredSpeed = GetPStats.GetMovementSpeed;
        GetPStats.SetMovementSpeed(SlowSpeed);
        Invoke("EndCooldown", 1.3f);
        Invoke("SpeedUp", 0.5f);
        Invoke("StartAttack", 0.35f);
    }

    public void EndCooldown()
    {
        GetPStats.SetAttackCooldown(false);
    }

    public void StartAttack()
    {
        if (!GetPStats.GetInAir)
        {
            NewExplosion = Instantiate(Explosion, transform.GetChild(0).position, transform.rotation);
            NewExplosion.GetComponent<Animator>().SetTrigger("Activate");
        }
        else
        {
            GameObject newFruit = Instantiate(Fruit, transform.GetChild(0).position, transform.rotation);
            Vector2 ShootSpeed = new Vector2(0, ProjectileSpeed);
            newFruit.GetComponent<Rigidbody2D>().AddRelativeForce(ShootSpeed);
            newFruit.GetComponent<Fruit>().SetAttackingPlayer(transform.gameObject);
        }
        
        IsAttacking = true;
        Invoke("StopAttacking", .8f);
    }

    public void StopAttacking()
    {
        IsAttacking = false;
        Destroy(NewExplosion);
    }

    public bool GetIsAttacking()
    {
        return IsAttacking;
    }

    public void SpeedUp()
    {
        GetPStats.SetMovementSpeed(StoredSpeed);
    }
}

