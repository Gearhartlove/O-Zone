using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

public class PlayerStats : MonoBehaviour
{
    private void Awake()
    {
        SetHealth();
    }

    //Movement + Physics variables
    [SerializeField] float MovementSpeed = 8f;
    float TempSpeed; //used to change speed
    bool isMoving = false;
    private bool inWaterBooster = false;
    [SerializeField] float burstSpeed = 80000;

    //Movement + Physics Properties
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public float BurstSpeed
    {
        get { return burstSpeed; }
    }

    public bool InWaterBooster
    {
        get { return inWaterBooster; }
        set { inWaterBooster = value; }
    }

    //-------------------------------------------------------------
    //rotation
    public float GetAngle(Vector2 me, Vector2 target)
    {
        //math for rotating spoon
        return Mathf.Atan2(target.y - me.y, target.x - me.x)
            * (180 / Mathf.PI);
    }

    //-------------------------------------------------------------
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

    //-------------------------------------------------------------
    //Bursting
    bool isBursting = false;
    private float burstLength = 1f;
    [SerializeField] private float slowOctoCD = 1f;
    [SerializeField] private float burstSlow = 900f;
    public float BURSTCD { get { return burstLength; } }
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
        IsDefensive = true;

        ChangeSpeed(BURSTSLOW);
        Invoke("StopBursting", BURSTCD);
        Invoke("BurstSlowOcto", SLOWOCTOCD);
        Invoke("StopDefense", DEFENSECD);
    }

    //-------------------------------------------------------------
    //Defensive / stun information
    [SerializeField] bool isDefensive = false;
    [SerializeField] float defenseCD = 1f; //time invincible
    [SerializeField] bool isStunned = false;
    [SerializeField] float stunLength = 1f;
    public float DEFENSECD { get { return defenseCD; } }
    public float StunLength { get { return stunLength; } }
    public bool IsDefensive
    {
        get { return isDefensive; }
        set { isDefensive = value; }
    }
    public bool IsStunned
    {
        get { return isStunned; }
        set { isStunned = value; }
    }
    public void StopDefense()
    {
        IsDefensive = false;
    }
    //-------------------------------------------------------------
    //Terrain variables
    [SerializeField] bool InAir = false;
    public bool GetInAir => InAir;

    public void SetInAir(bool change)
    {
        InAir = change;
    }
    //-------------------------------------------------------------
    // Combat variables
    [SerializeField] public float AttackCooldownTime;
    [SerializeField] bool isDead;
    [SerializeField] bool AttackCooldown = false;
    [SerializeField] private int MaxHealth = 2;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
    [SerializeField] private float InvincibilityTimer;
    [SerializeField] bool invincible;
    public bool Invincible
    {
        get { return invincible; }
        set
        {
            invincible = value;
            if (invincible)
            {
                Invoke("EndInvincibility", InvincibilityTimer);
            }
        }
    }
    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            //used when Octo's respawn and are set to max HP
            if (currentHealth == MaxHealth)
            {
                GetComponent<Animator>().SetInteger("Health", currentHealth);
            }
            //used when Octo's are damaged
            if (currentHealth != MaxHealth)
            {
                if (!IsDead)
                {
                    if (currentHealth <= 0 || currentHealth == 0)
                    {
                        GetComponent<Animator>().SetInteger("Health", currentHealth);
                        GetComponent<Animator>().SetTrigger("Damaged");
                        IsDead = true;
                        KillPlayer();
                        return;
                    }
                    GetComponent<Animator>().SetInteger("Health", currentHealth);
                    GetComponent<Animator>().SetTrigger("Damaged");
                    Invincible = true;
                }   
            }
        }
    }

    private void EndInvincibility()
    {
        Invincible = false;
    }

    private GameObject attackedByPlayer;

    public bool GetAttackCooldown => AttackCooldown;

    public void SetAttackCooldown(bool change)
    {
        AttackCooldown = change;
    }

    //set health to max
    public void SetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    //Fruit Damaging a player
    public void Damage(int damageAmount, GameObject player, Vector2 knockback)
    {
        if (IsDefensive)
        {
            //Stun attacking player
            PlayerStatus.StunAttackingPlayer(player);
            return;
        }
        else if (Invincible)
        {
            return;
        }
        AudioManager.PlaySound("Damaged");
        CurrentHealth -= damageAmount;
        Fruit.ApplyFruitKnockback(gameObject, knockback);       
    }

    //damaging a player with melee
    public void Damage(int damageAmount, GameObject player)
    {
        if (IsDefensive)
        {
            //Stun attacking player
            PlayerStatus.StunAttackingPlayer(player);
            return;         
        }
        else if (Invincible)
        {
            return;
        }
        AudioManager.PlaySound("Damaged");
        CurrentHealth -= damageAmount;
    }

    //Stage Damaging Player --> Instakill
    public void Damage(int damageAmount)
    {
        //ignore defense, stage kills anyway
        AudioManager.PlaySound("Damaged");
        CurrentHealth -= damageAmount;
    }

    public void KillPlayer()
    {
        AudioManager.PlaySound("Death");
        GetComponent<PlayerInput>().DeactivateInput();
        PlayerManager.DeadCount++;
    }
}
