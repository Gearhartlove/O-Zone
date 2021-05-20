using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerCombat : MonoBehaviour
{
    PlayerComponents PC;
    private bool IsAttacking = false;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Fruit;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float ProjectileSpeed;
    [SerializeField] private float AttackDuration;

    private float StoredSpeed;

    private GameObject NewExplosion;

    private void Awake()
    {
        //get base movement speed of the Octo
        PC = GetComponent<PlayerComponents>();
        StoredSpeed = PC.GetPStats.GetMovementSpeed;
    }

    public void Attack()
    {
        if (PC.GetPStats.GetAttackCooldown) // If on cooldown, exits the function immediately
        {
            return;
        }
        PC.GetPAnimator.SetTrigger("Attack");
        PC.GetPStats.SetAttackCooldown(true);
        Invoke("EndCooldown", PC.GetPStats.AttackCooldownTime);
        Invoke("StartAttack", 0.35f);

        //burst takes precidence over attacking
        //FYI, can attack at the tail end of bursting, and the attack slow will not
        //take into affect, can change later
        if (!PC.GetPStats.IsBursting)
        {
            PC.GetPStats.SetMovementSpeed(SlowSpeed);
            Invoke("SpeedUp", 0.5f);
        }
    }

    public void EndCooldown()
    {
        PC.GetPStats.SetAttackCooldown(false);
    }

    public void StartAttack()
    {
        if (!PC.GetPStats.GetInAir)
        {
            NewExplosion = Instantiate(Explosion, transform.GetChild(0).position, transform.rotation);
            NewExplosion.GetComponent<Animator>().SetTrigger("Activate");
            AudioManager.PlaySound("Melee");
        }
        else
        {
            GameObject newFruit = Instantiate(Fruit, transform.GetChild(0).position, transform.rotation);
            AudioManager.PlaySound("Projectile3");
            Vector2 ShootSpeed = new Vector2(0, ProjectileSpeed + PC.GetPRigidBody.velocity.magnitude);
            newFruit.GetComponent<Rigidbody2D>().AddRelativeForce(ShootSpeed);
            newFruit.GetComponent<Fruit>().SetAttackingPlayer(PC.GetPGameObject);
        }
        
        IsAttacking = true;
        Invoke("StopAttacking", AttackDuration);
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
        PC.GetPStats.SetMovementSpeed(StoredSpeed);
    }
}

