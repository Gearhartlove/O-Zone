using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player.PlayerComponents;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        int velocity = (int) GetPRigidBody.velocity.magnitude;
        GetPAnimator.SetInteger("Velocity", velocity);
    }
}
