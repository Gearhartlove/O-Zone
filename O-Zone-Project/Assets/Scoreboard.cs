using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;

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
    [SerializeField] private static float scoreboard_delay = 4f;
    public static float GetScoreboard_Delay => scoreboard_delay;
    [SerializeField] GameObject StartingSpot;
    private Vector3 StartingOctoPos;
    [SerializeField] GameObject ScoreboardOctoPrefab;
    [SerializeField] GameObject ScoreboardPointPrefab;
    Canvas canvas;
    static CanvasGroup canvas_group;
    public static bool IgnoreScoreboard = false;

    private void Awake()
    {
        //initialize if X does not already exist 
        DontDestroyOnLoad(this);
        if (SB == null) SB = this;
        else { Destroy(this); }
        if (ScoreboardOctos == null)
            ScoreboardOctos = new List<ScoreboardOcto>();
        PM = Game_Manager.GetPM;
        canvas = GetComponent<Canvas>();
        StartingOctoPos = StartingSpot.transform.position;
    }

    //Called by ShowScoreboard(), increments points and triggers crown anim
    public static void WinARound()
    {
        int winner = PlayerManager.CheckWinner();
        ScoreboardOctos[winner].IncrementPoint();
        //check if the Octo won the round
        if (ScoreboardOctos[winner].GetPointScore == GameplayRules.RoundCount)
        {
            Winner(ScoreboardOctos[winner]);
        }

    }

    //Called by WinARound, when an Octo wins the game (max amount of rounds)
    public static void Winner(ScoreboardOcto winner)
    {
        //trigger winning animation
        //winner.animator.Play("WinningAnimation");
        //TODO Prompt players to play again or return to main menu
    }

    //Called in PlayerManager, when the Octo connects their controller
    //creates : ScoreboardOcto (parent) with ScoreboardPoints (children)
    //ScoreboardPoints depends on the GameplayRules.RoundCount amount
    public void AddPlayerToScoreboard()
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
}
