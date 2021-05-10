using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //FIELDS
    //Privatef
    //player array
    [SerializeField] static GameObject[] PArray;
    PlayerInputManager PInputManager;
    private static int pCount = 0;
    private static int deadCount = 0;

    //Public 
    //readonly property, public access to pCount
    public int PCount {get{return pCount;}}
    public static int DeadCount
    {
        get { return deadCount; }
        set { deadCount = value; }
    }

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
        Debug.Log(PCount);
    }

    public static bool CheckAliveP()
    {
        if (pCount == 1) return false;

        if (DeadCount == (pCount-1))
        {
            return true;
        }
        return false;
    }

    //set hp to full
    public static void ResetPlayers()
    {
        foreach (GameObject player in PArray)
        {
            //PlayerStats PS = player.GetComponent<PlayerStats>();
            //PS.SetHealth();
        }
    }

    public static void SpawnOctos()
    {
        foreach (GameObject player in PArray)
        {
            
        }
    }
    
    //dissable players from joining

    //dissable a player's controls


    //remove players from the array
    
}
