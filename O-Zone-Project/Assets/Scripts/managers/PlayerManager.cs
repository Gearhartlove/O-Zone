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
    [SerializeField] static Stage stage;
    private static int pCount = 0;
    private static int deadCount = 0;
    //Public 
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
                Debug.Log("Death Count: " + deadCount);
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

        stage = GameObject.Find("TheStage").GetComponent<Stage>();
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        PArray[PCount] = player.gameObject;
        GetComponent<ColorManager>().SwapPalette(player.gameObject, PCount);
        pCount++;
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
}
