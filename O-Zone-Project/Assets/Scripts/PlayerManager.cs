using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //FIELDS
    //Private
    //player array
    [SerializeField] GameObject[] PArray;
    PlayerInputManager PInputManager;
    private int pCount = 0;

    //Public 
    //readonly property, public access to pCount
    public int PCount {get{return pCount;}}

    //METHODS
    private void Start()
    {
        PInputManager = gameObject.GetComponent<PlayerInputManager>();
        PArray = new GameObject[4];
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        PArray[PCount] = player.gameObject;
        pCount++;
        Debug.Log(PCount);
    }


    
}
