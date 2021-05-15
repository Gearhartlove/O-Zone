using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static Manager.Game_Manager;

public class Scene_Manager : MonoBehaviour
{
    static PlayerManager PM;
    [SerializeField] Canvas UICanvas;
    [SerializeField] Stage[] StageArray;
    int Tm_length;
    [SerializeField] int[] TilemapChecker;

    private void Awake()
    {
        PM = GetComponent<PlayerManager>();
        Tm_length = StageArray.Length;
        TilemapChecker = new int[Tm_length];
        //CurrentTileMap = 
    }

    public void LoadMainMenu()
    {
        //load the main menu
    }

    public void StartGame()
    {
        //>> placholder : animation to start game
        //load first stage
        SceneManager.LoadScene(1);
        //load game with all Octo's round counts at 0
    }

    //load random stage
    public static void LoadStage()
    {
        PM.ResetPlayers();  //reset health
        SceneManager.LoadScene(1);
        PM.SpawnOctos();    //spawn players

    }
}