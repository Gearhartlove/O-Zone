using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Movement + Physics values
    [SerializeField] float RotationSpeed = 8f;
    [SerializeField] float MovementSpeed = 8f;
    [SerializeField] float MaximumSpeed = 10f; //de-serialize later TODO
    float TempSpeed; //used to change speed
    bool isMoving = false;
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    [SerializeField] float burstSpeed = 80000;
    public float BurstSpeed
    {
        get { return burstSpeed; }
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

    public void ChangeSpeed(float val)
    {
        //slowing
        SetMovementSpeed(val);
    }

    //Bursting
    bool isBursting = false;
    private float burstLength = 1f;
    [SerializeField] private float slowOctoCD = 1f;
    [SerializeField] private float burstSlow = 900f;
    public float BURSTCD { get {return burstLength;} }
    public float BURSTSLOW { get { return burstSlow; } }
    public float SLOWOCTOCD { get { return slowOctoCD; } }
    public bool IsBursting
    {
        get { return isBursting; }
        set { isBursting = value; }
    }

    private void StopBursting() => isBursting = false;  

    public void BurstSlowOcto() => ChangeSpeed(TempSpeed);

    public void CallStopBursting()
    {
        TempSpeed = GetMovementSpeed;
        ChangeSpeed(BURSTSLOW);
        Invoke("StopBursting", BURSTCD);
        Invoke("BurstSlowOcto", SLOWOCTOCD);
    }

    //Defensive / stun information
    [SerializeField] bool isDefensive = false;
    bool IsDefensive
    {
        get { return isDefensive; }
        set { isDefensive = value; }
    }

    //Terrain
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
