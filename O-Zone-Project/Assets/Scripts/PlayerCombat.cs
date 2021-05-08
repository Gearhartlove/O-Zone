using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player.PlayerComponents;

public class PlayerCombat : MonoBehaviour
{
    private bool IsAttacking = false;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private float SlowSpeed;
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
        Invoke("EndCooldown", 1f);

        Invoke("StartAttack", 0.35f);
    }

    public void EndCooldown()
    {
        GetPStats.SetAttackCooldown(false);
    }

    public void StartAttack()
    {
        NewExplosion = Instantiate(Explosion, transform.GetChild(0).position, transform.rotation);
        NewExplosion.GetComponent<Animator>().SetTrigger("Activate");
        IsAttacking = true;
        Invoke("StopAttacking", .8f);
    }

    public void StopAttacking()
    {
        IsAttacking = false;
        Destroy(NewExplosion);
        GetPStats.SetMovementSpeed(StoredSpeed);
    }

    public bool GetIsAttacking()
    {
        return IsAttacking;
    }
}

