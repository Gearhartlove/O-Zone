using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Player.PlayerComponents;

public class PlayerControls : MonoBehaviour
{
    PlayerStats PS;
    PlayerCombat PC;

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
        PC = GetComponent<PlayerCombat>();
    }

    private void OnWestButton()
    {
        //BURST : fast set movement in water, small pause afterwords
        if (!PS.IsBursting)
        //if (!PS.GetInAir || !PS.GetInWaterBooster)
        {
            PS.IsBursting = true;
            GetPAnimator.SetTrigger("Big Swim");
            GetComponent<ParticleSystem>().Play();
            PS.CallStopBursting();
            GetPRigidBody.AddRelativeForce(Vector2.up * PS.BurstSpeed);          
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
        PC.Attack();
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
            GetPTransform.rotation = Quaternion.Euler(0, 0, angle);
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
            GetPRigidBody.AddRelativeForce
                (Vector2.up * PS.GetMovementSpeed * Time.deltaTime);
            //}
        }
    }

    private void OnStart()
    {

    }

    private void OnTempAction() //delete after testing
    {

    }
}
