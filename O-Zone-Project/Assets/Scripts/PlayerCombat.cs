using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player.PlayerComponents;

public class PlayerCombat : MonoBehaviour
{
    private bool IsAttacking = false;

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

        GetPStats.SetAttackCooldown(true);
        Invoke("EndCooldown", 1f);

        Invoke("StartAttack", 0.1f);
    }

    public static void EndCooldown()
    {
        GetPStats.SetAttackCooldown(false);
    }

    public void StartAttack()
    {
        IsAttacking = true;
        Invoke("StopAttacking", 0.4f);
    }

    public void StopAttack()
    {
        IsAttacking = false;
    }
}

