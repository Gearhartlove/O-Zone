using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //FIELDS
    //Privatef
    //player array
    [SerializeField]public static GameObject[] PArray;
    [SerializeField] static Stage stage;
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

        SB = GameObject.Find("ScoreBoardCanvas").GetComponent
            <Scoreboard>();
        PIndicatorManager = GameObject.Find("PlayerIndicatorCanvas").GetComponent<PlayerIndicatorManager>();

        //if not the main menu, find the stage
        //NOTE: not the cleanest solution, will not work well with menuing
        //and future content, bandade for now 
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            != "MainMenu")
            stage = GameObject.Find("Stage").GetComponent<Stage>();

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
    public void ResetPlayers()
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
            PS.GetComponent<PlayerInput>().ActivateInput();
            PS.SetHealth();
            //death animation state to normal idle animation state
            ANIM.Play("Idle");
            //return octo to water
            RB.gravityScale = 0f;

            deadCount = 0;    
        }
    }

    public void SpawnOctos()
    {
        for (int i = 0; i < pCount; i++)
        { 
            PArray[i].transform.position = stage.SpawnPoints[i].transform.position;
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

}
