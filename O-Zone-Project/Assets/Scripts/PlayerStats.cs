using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Movement + Physics values
    [SerializeField] float RotationSpeed = 8f;
    [SerializeField] float MovementSpeed = 8f;
    [SerializeField] float MaximumSpeed = 10f; //de-serialize later TODO
    bool isMoving = false;
    public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; } 
        }

    [SerializeField] float burstSpeed = 80000;
    public float BurstSpeed
    {
        get {return burstSpeed; }
    }
    private bool inWaterBooster = false;
    public bool InWaterBooster
    {
        get { return inWaterBooster; }
        set { inWaterBooster = value; }
    }
        
    //SceneLogic
    int round_win_count;
    [SerializeField] bool InAir = false;
    

    public void RoundWin() { round_win_count++; }

    //rotation
    public float GetRotationSpeed => RotationSpeed;
    public float GetMaxSpeed => MaximumSpeed;
    public float GetAngle(Vector2 me, Vector2 target)
    {
        //math for rotating spoon
        return Mathf.Atan2(target.y - me.y, target.x - me.x)
            * (180 / Mathf.PI);
    }

    //movement
    public float GetMovementSpeed => MovementSpeed;
    public void SetMovementSpeed(float speed)
    {
        MovementSpeed = speed;
    }
    public bool GetInWaterBooster => InWaterBooster;

    //terrain
    public bool GetInAir => InAir;

    public void SetInAir(bool change)
    {
        InAir = change;
    }

    // Combat Values
    [SerializeField] float AttackCooldownTime;
    [SerializeField] bool AttackCooldown = false;
    [SerializeField] int Health = 2;

    public bool GetAttackCooldown => AttackCooldown;

    public void SetAttackCooldown(bool change)
    {
        AttackCooldown = change;
    }

    public void Damage(int damageAmount)
    {
        GetComponent<Animator>().SetTrigger("Damaged");
        Health -= damageAmount;
        if (Health <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        // Kill inputs
    }
}
