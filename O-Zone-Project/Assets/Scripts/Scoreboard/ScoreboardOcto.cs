using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ScoreboardOcto : MonoBehaviour
{
    ScoreboardPoint[] Points;
    public ScoreboardPoint[] GetPoints => Points;
    private int point_score = 0;
    public int GetPointScore => point_score;
    private Animator octoAnimator;
    public Animator GetAnimator => octoAnimator;

    private void Awake()
    {
        octoAnimator = GetComponent<Animator>();
        Points = new ScoreboardPoint[GameplayRules.RoundCount];
    }

    //IncrementPoint //check if won
    public void IncrementPoint()
    {
        Points[point_score].ScorePoint();
        point_score++;
    }

    public void ResetPoints()
    {
        point_score = 0;
    }

    public void DecrementPoint(int i )
    {
        Points[i].LosePoint();
    }
}
