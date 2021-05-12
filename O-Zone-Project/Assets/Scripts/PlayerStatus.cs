using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    PlayerComponents PC;
    GameObject StunnedPlayer;
    [SerializeField] private float StunLength;

    private void Start()
    {
        PC = GetComponent<PlayerComponents>();
    }

    public static void StunAttackingPlayer(GameObject player)
    {
        player.GetComponent<PlayerStats>().IsStunned = true;
        //add stun functionality (AKA don't give players input ability)
        player.GetComponent<PlayerInput>().DeactivateInput();
        player.GetComponent<Animator>().SetTrigger("Stunned");
        player.GetComponent<PlayerStatus>().StopStunCall(player);
    }

    public void StopStunCall(GameObject player)
    {
        StunnedPlayer = player;
        Invoke("StopStun", StunLength);
       
    }

    public void StopStun()
    {
        StunnedPlayer.GetComponent<PlayerStats>().IsStunned = false;
        StunnedPlayer.GetComponent<PlayerInput>().ActivateInput();
    }
}
