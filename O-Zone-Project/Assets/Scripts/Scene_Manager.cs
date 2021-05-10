using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static Manager.Game_Manager;

public class Scene_Manager : MonoBehaviour
{ 
    [SerializeField] Canvas UICanvas;
    [SerializeField] Stage[] StageArray;
    [SerializeField] Stage CurrentStage;
    int Tm_length;
    [SerializeField] int[] TilemapChecker;

    private void Start()
    {
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
        //animation to start game
        //load first stage
        SceneManager.LoadScene(1);
        //load game with all Octo's round counts at 0
    }

    public static void NextRound()
    {
        PlayerManager.DeadCount = 0;
        PlayerManager.ResetPlayers();  //reset health
        PlayerManager.SpawnOctos();    //spawn players
    }

    //load random stage
    public void LoadStage()
    {
        NextRound();
        SceneManager.LoadScene(1);
        //int Rnum = GenRN(Tm_length); //Random Number
        //1 = used already
        //while(TilemapChecker[Rnum] == 1)
       // {
            //get a map that hasen't been used before
            //Rnum = GenRN(Tm_length);
        //}
        //change the tilemap
        //CurrentStage = StageArray[Rnum];
        //set map to used
        //TilemapChecker[Rnum] = 1;

    }

    private void ResetTileMapChecker()
    {
        for (int i = 0; i<TilemapChecker.Length; i++)
        {
            TilemapChecker[i] = 0;
        }
    }
}