using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Manager;

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

    //connected to the MainMenu Button
    public void LoadMainMenu()
    {
        Debug.Log("Main Menu Loading");
        //load the main menu
        Game_Manager.GetStageManager.LoadMainMenu();
    }

    public void PrepareNextRound()
    {
        Scoreboard.HideScoreboard();
        Game_Manager.GetStageManager.LoadStageRandom();
        Countdown.StartCountdown(); //Start Countdown into game
        PM.DisablePlayerControls();
        PM.SpawnOctos();    //spawn players
        PM.ResetPlayerStats();
    }

    //connected to the RestartGameButton
    public static void NewGame()
    {
        SM.StartCoroutine(SM.RestartGame());
    }

    //Called by NewGame()
    public IEnumerator RestartGame()
    {
        PrepareNextRound();
        Scoreboard.ResetScoreboard();
        yield return new WaitForSeconds(Countdown.GetCountdown_Delay);
        PM.ResetPlayerControls();
    }

    //static method which calss EndOfRound
    //called by DeadCount Parameter in DeadCount
    public static void LoadStage()
    {
        //call delay till the next round starts
        SM.StartCoroutine(SM.EndOfRound(delay_after_death)); 
    }

    //Interacts with scoreboard to present the Scoreboard UI after each round 
    public IEnumerator EndOfRound(float wait_time)
    {
        yield return new WaitForSeconds(wait_time); //wait after last death
        if (!Scoreboard.IgnoreScoreboard) //for testing purposes
        {
            Scoreboard.ShowScoreboard(); //scoreboard UI, increment winner's crown count
        }
        if (!Scoreboard.IsGameOver)
        {
            yield return new WaitForSeconds(Scoreboard.GetScoreboard_Delay);
            PrepareNextRound();
            yield return new WaitForSeconds(Countdown.GetCountdown_Delay);  
            PM.ResetPlayerControls();
        }
        //else game is over do you want to restart the game?
        else
        {
            yield return new WaitForSeconds(Scoreboard.GetScoreboard_Delay);
            Scoreboard.Winner();
        }
    }
}