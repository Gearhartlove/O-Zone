using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Manager;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// All members pertaining to the Scoreboard are used in this script. The
/// "child scripts" are the ScoreboardOcto and ScoreboardPoint. Both of these
/// scripts are attatched to prefabs called ScoreboardOcto an Scoreboard perfabs.
/// The Scoreboard appears and dissappears in Scene_Manager 'EndOfRound'.
/// The length of the time the scoreboard is showing is determened by the
/// scoreboard_delay variable.
/// </summary>
public class Scoreboard : MonoBehaviour
{
    static Scoreboard SB;
    PlayerManager PM;
    static List<ScoreboardOcto> ScoreboardOctos;
    [SerializeField] private static float scoreboard_delay = 2.5f;
    public static float GetScoreboard_Delay => scoreboard_delay;
    [SerializeField] GameObject StartingSpot;
    private Vector3 StartingOctoPos;
    [SerializeField] GameObject ScoreboardOctoPrefab;
    [SerializeField] GameObject ScoreboardPointPrefab;
    Canvas canvas;
    static CanvasGroup canvas_group;
    public static bool IgnoreScoreboard = false;
    public static bool IsGameOver = false;
    //static Button mainMenuButton;
    //public static Button MainMenuButton => mainMenuButton;
    //private static TextMeshProUGUI MainMenuText;
    static Button restartGameButton;
    public static Button RestartGameButton => restartGameButton;
    private static TextMeshProUGUI RestartGameText;
    


    private void Awake()
    {
        //initialize if X does not already exist 
        DontDestroyOnLoad(this);
        if (SB == null) SB = this;
        else { Destroy(this.gameObject); }
        if (ScoreboardOctos == null)
            ScoreboardOctos = new List<ScoreboardOcto>();
        PM = Game_Manager.GetPM;
        canvas = GetComponent<Canvas>();
        StartingOctoPos = StartingSpot.transform.position;
        //buttons (need to be active)

        //mainMenuButton = GameObject.Find("MainMenuButton").
        //    GetComponent<Button>();
        //if (MainMenuText == null)
        //    MainMenuText = MainMenuButton.GetComponentInChildren<TextMeshProUGUI>();
        //MainMenuText.gameObject.SetActive(false);
        //mainMenuButton.interactable = false;


        restartGameButton = GameObject.Find("RestartGameButton").
            GetComponent<Button>();
        if (RestartGameText == null)
            RestartGameText = RestartGameButton.GetComponentInChildren<TextMeshProUGUI>();
        RestartGameText.gameObject.SetActive(false);
        restartGameButton.interactable = false;
    }

    //Called by ShowScoreboard(), increments points and triggers crown anim
    public static void WinARound()
    {
        int winner = PlayerManager.CheckWinner();
        ScoreboardOctos[winner].IncrementPoint();
        //check if the Octo won the round
        if (ScoreboardOctos[winner].GetPointScore == GameplayRules.RoundCount)
        {
            IsGameOver = true;
        }
    }

    //Called by WinARound, when an Octo wins the game (max amount of rounds)
    //presents options to restart the round or 
    public static void Winner()
    {
        //MainMenuButton.interactable = true;
        //MainMenuText.gameObject.SetActive(true);
        RestartGameButton.interactable = true;
        RestartGameText.gameObject.SetActive(true);
        SelectRestartButton();
    }

    //Called in PlayerManager, when the Octo connects their controller
    //creates : ScoreboardOcto (parent) with ScoreboardPoints (children)
    //ScoreboardPoints depends on the GameplayRules.RoundCount amount
    public void AddPlayerToScoreboard(PlayerInput player)
    {
        GameObject Octo = Instantiate(ScoreboardOctoPrefab);
        //add to Octo Array
        ScoreboardOctos.Add(Octo.GetComponent<ScoreboardOcto>());
        //set parent
        Octo.transform.SetParent(canvas.transform, true);
        //set position
        Octo.transform.position = StartingOctoPos;
        //change the spawning position of the octos
        StartingOctoPos.y -= 145;
        //reset the point pos. value for each octo
        Vector3 StartingPointPos = Octo.transform.position;
        //Add Points as children
        for (int l = 0; l < GameplayRules.RoundCount; l++)
        {
            SpawnScoreboardPoint(Octo, ref StartingPointPos, l);
        }

        //Gets object from player input to match palettes
        Texture2D playerPalette = player.gameObject.GetComponent<octoPaletteSwapTest>().GetSwapPalette();
        Octo.GetComponent<UIPaletteSwap>().SetSwapPalette(playerPalette);

        //canvas group updates after each Octo is added
        canvas_group = GetComponent<CanvasGroup>();
    }

    //used to position the ScoreboardPoint prefabs on the canvas automatically
    private void SpawnScoreboardPoint(GameObject Octo, ref Vector3 pos, int l)
    {
        pos.x += 130;
        GameObject Point = Instantiate(ScoreboardPointPrefab);
        Point.transform.SetParent(Octo.transform, true);
        Point.transform.position = pos;
        //add point to Scoreboard Point array
        Octo.GetComponent<ScoreboardOcto>().GetPoints[l] =
            Point.GetComponent<ScoreboardPoint>();
    }

    public static void ShowScoreboard()
    {
        //show scoreboard
        canvas_group.alpha = 1f;
        WinARound();
    }

    public static void HideScoreboard() => canvas_group.alpha = 0f;

    public static void ResetScoreboard()
    {
        IsGameOver = false;
        foreach (ScoreboardOcto octo in ScoreboardOctos)
        {
            octo.ResetPoints();
            for (int i = 0; i < GameplayRules.RoundCount; i++)
            {
                octo.DecrementPoint(i); 
            }
        }
    }

    //selects button once an Octo has won 
    public static void SelectRestartButton()
    {
        EventSystem e = GameObject.Find("EventSystem").
         GetComponent<EventSystem>();
        e.SetSelectedGameObject(RestartGameButton.
            gameObject);
    }
}

