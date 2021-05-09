using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

public class PlayerControls : MonoBehaviour
{
    PlayerStats PS;
    PlayerCombat PCombat;
    PlayerComponents PComponents;

    //defensive move to protect player
    bool isDefensive = false;
    [SerializeField] float stunLength = 0;
    [SerializeField] bool IsDefensive
    {
        get { return isDefensive; }
        set { isDefensive = value; }
    }  

    private void Awake()
    {
        PS = GetComponent<PlayerStats>();
        PCombat = GetComponent<PlayerCombat>();
        PComponents = GetComponent<PlayerComponents>();
    }

    private void OnWestButton()
    {
        //BURST : fast set movement in water, small pause afterwords
        if (!PS.IsBursting)
        //if (!PS.GetInAir || !PS.GetInWaterBooster)
        {
            PS.IsBursting = true;
            PComponents.GetPAnimator.SetTrigger("Big Swim");
            GetComponent<ParticleSystem>().Play();
            PS.CallStopBursting();
            PComponents.GetPRigidBody.AddRelativeForce(Vector2.up * PS.BurstSpeed);          
        }
    }

    private void OnEastButton()
    {

    }

    private void OnNorthButton()
    {

    }

    private void OnSouthButton()
    {
        PCombat.Attack();
    }

    private void OnLeftTrigger()
    {

    }

    private void OnRightTrigger()
    {

    }

    private void OnRightStick(InputValue value)
    {

    }

    //player rotation script
    private void OnLeftStick(InputValue value)
    {
        Vector2 input = value.Get<Vector2>().normalized;

        //ROTATE the Player
        float angle = PS.GetAngle(Vector2.zero, input);

        angle -= 90f; //fix rotation of octo

        if (input.sqrMagnitude > 0.1f)
        {
            //avoid jerking back to rotation 0
            PComponents.GetPTransform.rotation = Quaternion.Euler(0, 0, angle);
            //Player is moving
            PS.IsMoving = true;
        }
        else
        {
            //Playser is no longer moving
            PS.IsMoving = false;
        }

        
    }

    //PlayerMovement
    private void Update()
    {
        //MOVE the player
        if (!PS.GetInAir && PS.IsMoving)
        {

            //If the player is going faster than the desired maximum speed,
            //add force in the opposite direction to slow down the player
            //if (CurrentSpeed > PS.GetMaxSpeed)
            //{
            //    //difference between current and maximum speed
            //    float SpeedDifference = (CurrentSpeed - PS.GetMaxSpeed);
            //    GetPRigidBody.AddRelativeForce
            //        (Vector2.down * (SpeedDifference) * Time.deltaTime);
            //}
            //else //speed up the player 
            //{
            PComponents.GetPRigidBody.AddRelativeForce
                (Vector2.up * PS.GetMovementSpeed * Time.deltaTime);
            //}
        }

        if (PS.GetInAir && GetComponent<Rigidbody2D>().velocity.magnitude == 0)
        {
            PS.Damage(1000);
        }
    }

    private void OnStart()
    {

    }

    private void OnTempAction() //delete after testing
    {

    }
}
