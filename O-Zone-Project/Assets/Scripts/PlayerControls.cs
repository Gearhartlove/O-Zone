using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Player.PlayerComponents;

public class PlayerControls : MonoBehaviour
{
    private void OnWestButton()
    {
        //Animator k = GetPAnimator;
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
        //Debug.Log("value: " + value.Get<Vector2>()); ;
    }

    private void OnLeftStick(InputValue value)
    {

    }

    private void OnStart()
    {

    }

    private void OnTempAction() //delete after testing
    {
        Debug.Log("temp");
    }
}
