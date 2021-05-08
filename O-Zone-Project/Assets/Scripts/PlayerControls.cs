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
        //rotate the Player
        Vector2 input = value.Get<Vector2>();

        float angle = PS.GetAngle(Vector2.zero, input);
        if (input.sqrMagnitude > 0.1f)
            GetPTransform.rotation = Quaternion.Euler(0, 0, angle);

        //move the player if in water;
        if (PS.GetInWater)
        {
            GetPRigidBody.AddForce(transform.up * PS.GetMovementSpeed);
        }
        //Vector3 move = input; //vector 2 to vector 3
        //GetPTransform.position += move * PS.GetMovementSpeed * Time.deltaTime;

    }

    private void OnStart()
    {

    }

    private void OnTempAction() //delete after testing
    {
        Debug.Log("temp");
    }
}
