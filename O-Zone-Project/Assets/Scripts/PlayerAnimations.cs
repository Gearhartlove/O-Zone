using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerAnimations : MonoBehaviour
{
    PlayerComponents PC;

    private void Start()
    {
        PC = GetComponent<PlayerComponents>();
    }

    void Update()
    {
        int velocity = (int) PC.GetPRigidBody.velocity.magnitude;
        PC.GetPAnimator.SetInteger("Velocity", velocity);
    }
}
