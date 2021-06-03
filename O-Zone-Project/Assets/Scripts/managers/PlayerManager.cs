using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //FIELDS
    //Privatef
    //player array
    public static GameObject[] PArray;
    [SerializeField] Stage CurrentStage; //remove later TODO
    private static int pCount = 0;
    private static int deadCount = 0;

    //Public
    Scoreboard SB;
    PlayerIndicatorManager PIndicatorManager;
    //readonly property, public access to pCount
    public static int PCount {get{return pCount;}}
    //logic for restarting the game 
    public static int DeadCount
    {
        get { return deadCount; }
        set
        {
            
            //else
            deadCount++;
            
            //special case for only one player
            if (pCount == 1)
            {
                deadCount = 0;
                Scene_Manager.LoadStage();
                return;
            }
            if (deadCount == pCount - 1) //one player left alive
            {
                //LoadNewScene
                Scene_Manager.LoadStage();
            }
        }
    }

    //METHODS
    private void Awake()
    {
        if (PArray == null)
        {
            PArray = new GameObject[4];
        }

        //if (CurrentStage == null)
        //{
        //    Stage.Assign_Stage(CurrentStage);
        //    GrabStage();
        //}

        SB = GameObject.Find("ScoreBoardCanvas").GetComponent
            <Scoreboard>();
        PIndicatorManager = GameObject.Find("PlayerIndicatorCanvas").GetComponent<PlayerIndicatorManager>();
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        PArray[PCount] = player.gameObject;
        GetComponent<ColorManager>().SwapPalette(player.gameObject, PCount);
        pCount++;

        //Add player to scoreboard
        SB.AddPlayerToScoreboard(player);
        PIndicatorManager.AddPlayerIndicator();
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
    public void ResetPlayerStats()
    {
        for (int i = 0; i < pCount; i++)
        {
            PlayerStats PS =
                PArray[i].GetComponent<PlayerStats>();
            Rigidbody2D RB =
                PArray[i].GetComponent<Rigidbody2D>();
            Animator ANIM =
                PArray[i].GetComponent<Animator>();

            PS.SetInAir(false);
            PS.IsDead = false;
            PS.SetHealth();
            //death animation state to normal idle animation state
            ANIM.Play("Idle");
            //return octo to water
            RB.gravityScale = 0f;

            deadCount = 0;    
        }
    }

    public void ResetPlayerControls()
    {
        for (int i = 0; i < pCount; i++)
        {
            PlayerStats PS =
                PArray[i].GetComponent<PlayerStats>();
            PS.GetComponent<PlayerInput>().ActivateInput();
        }
    }


    public void SpawnOctos()
    {
        for (int i = 0; i < pCount; i++)
        {
            PArray[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            PArray[i].GetComponent<Rigidbody2D>().angularVelocity = 0f;
            PArray[i].transform.position = CurrentStage.SpawnPoints[i].transform.position;
        }
    }

    public static int CheckWinner()
    {
        int player = 0;
        //only one person
        if (PCount == 1) { return 0; }
        //more than 1 person
        foreach (GameObject Octo in PArray)
        {
            if (Octo != null)
            {
                if (!Octo.GetComponent<PlayerStats>().IsDead)
                    break;
                player++;
            }
        }
        return player;
    }

    public void DisablePlayerControls()
    {
        for (int i = 0; i < pCount; i++)
        {
            PlayerStats PS =
                PArray[i].GetComponent<PlayerStats>();
            PS.GetComponent<PlayerInput>().DeactivateInput();
        }
    }
}
