using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //FIELDS
    //Privatef
    //player array
    [SerializeField] GameObject[] PArray;
    PlayerInputManager PInputManager;
    private int pCount = 0;

    //Public 
    //readonly property, public access to pCount
    public int PCount {get{return pCount;}}

    //METHODS
    private void Awake()
    {
        PInputManager = gameObject.GetComponent<PlayerInputManager>();
        PArray = new GameObject[4];
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        PArray[PCount] = player.gameObject;
        GetComponent<ColorManager>().SwapPalette(player.gameObject, PCount);
        pCount++;
    }

    //dissable players from joining

    //dissable a player's controls


    //remove players from the array
    
}
