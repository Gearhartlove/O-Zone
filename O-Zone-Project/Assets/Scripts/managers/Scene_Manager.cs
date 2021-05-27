using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static Manager.Game_Manager;

public class Scene_Manager : MonoBehaviour
{
    static PlayerManager PM;
    static Scene_Manager SM;
    [SerializeField] Stage[] StageArray;
    int Tm_length;
    [SerializeField] int[] TilemapChecker;
    private static float delay_after_death = 1.5f;

    private void Awake()
    {
        PM = GetComponent<PlayerManager>();
        if (SM == null) SM = GetComponent<Scene_Manager>();
        else Destroy(this);
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
        //call delay till the next round starts
        SM.StartCoroutine(SM.EndOfRound(delay_after_death)); 
    }

    public IEnumerator EndOfRound(float wait_time)
    {
        yield return new WaitForSeconds(wait_time); //wait after last death
        if (!Scoreboard.IgnoreScoreboard) //for testing purposes
        {
            Scoreboard.ShowScoreboard(); //scoreboard UI, increment winner's crown count
            yield return new WaitForSeconds(Scoreboard.GetScoreboard_Delay);
            Scoreboard.HideScoreboard();
        }
        //Bring Up ScoreBoard
        //wait again ScoreBoard.GetScoreboardDelay
        PM.ResetPlayers();  //reset health
        SceneManager.LoadScene(0); 
        PM.SpawnOctos();    //spawn players
    }
}