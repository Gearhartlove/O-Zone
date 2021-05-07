using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Manager.Game_Manager;

public class SceneManager : MonoBehaviour
{ 
    [SerializeField] Canvas UICanvas;
    [SerializeField] Tilemap[] TilemapArray;
    [SerializeField] Tilemap CurrentTileMap;
    int Tm_length;
    [SerializeField] int[] TilemapChecker;

    private void Start()
    {
        Tm_length = TilemapArray.Length;
        TilemapChecker = new int[Tm_length];
        //CurrentTileMap = 
    }

    public void LoadMainMenu()
    {
        //load the main menu, accessed from pause menu

    }

    public void StartGame()
    {
        //load game with all Octo's round counts at 0
    }

    public void NextRound()
    {
        //load next map with Octo's round counts saved

    }

    //load random stage
    public void LoadStage()
    {
        int Rnum = GenRN(Tm_length); //Random Number
        //1 = used already
        while(TilemapChecker[Rnum] == 1)
        {
            //get a map that hasen't been used before
            Rnum = GenRN(Tm_length);
        }
        //change the tilemap
        CurrentTileMap = TilemapArray[Rnum];
        //set map to used
        TilemapChecker[Rnum] = 1;

    }

    private void ResetTileMapChecker()
    {
        for (int i = 0; i<TilemapChecker.Length; i++)
        {
            TilemapChecker[i] = 0;
        }
    }
}
