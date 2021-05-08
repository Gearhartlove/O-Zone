using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Player.PlayerComponents;
using Player;

public class PlayerControls : MonoBehaviour
{
    PlayerStats PS;

    private void Start()
    {
        PS = gameObject.GetComponent<PlayerStats>();
    }

    private void OnWestButton()
    {
        Debug.Log("west");
    }

    private void OnEastButton()
    {

    }

    private void OnNorthButton()
    {

    }

    private void OnSouthButton()
    {

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

    private void OnLeftStick(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Debug.Log(input);
        float CurrentSpeed = GetPRigidBody.velocity.magnitude;

        //ROTATE the Player
        float angle = PS.GetAngle(Vector2.zero, input);
        angle -= 90f;
        //if (input.sqrMagnitude > 0.1f)
        //{
        //    //avoid jerking back to rotation 0
            GetPTransform.rotation = Quaternion.Euler(0, 0, angle);
        //    //turn off linear drag
        //   // GetPRigidBody.drag = 0.2f;
        //}
        //else
        //{
        //    //reset linear drag
        //    Debug.Log("resetting");
        //    //GetPRigidBody.drag = PS.GetLinearDrag;
        //}

        //MOVE the player
        if (PS.GetInWater)
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
        Debug.Log("temp");
    }
}
