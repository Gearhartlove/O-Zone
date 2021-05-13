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
    private bool playingSwimSound = false;

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
            AudioManager.PlaySound("Dodge");
            GetComponent<ParticleSystem>().Play();
            PS.CallStopBursting();
            PComponents.GetPRigidBody.AddRelativeForce(Vector2.up * PS.BurstSpeed);          
        }
    }

    private void OnEastButton()
    { 
    }

    private void OnSouthButton()
    {
        PCombat.Attack();
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
            PComponents.GetPRigidBody.AddRelativeForce
                (Vector2.up * PS.GetMovementSpeed * Time.deltaTime);
            //}
            
        } 

        if(!PS.GetInAir && PComponents.GetPRigidBody.velocity.magnitude > 1.5f)
        {
            if (!playingSwimSound)
            {
                InvokeRepeating("PlaySwimSound", 0.1f, 0.75f);
                playingSwimSound = true;
            }
        }
        else
        {
            CancelInvoke();
            playingSwimSound = false;
        }
    }

    private void OnStart()
    {
        //join the game
    }

    private void PlaySwimSound()
    {
        AudioManager.PlaySound("Swim");
    }
}
