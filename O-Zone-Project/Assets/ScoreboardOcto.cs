using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardOcto : MonoBehaviour
{
    ScoreboardPoint[] Points;
    public ScoreboardPoint[] GetPoints => Points;
    private int point_score = 0;
    public int GetPointScore => point_score;

    private void Awake()
    {
        Points = new ScoreboardPoint[GameplayRules.RoundCount];
    }

    //IncrementPoint //check if won
    public void IncrementPoint()
    {
        Points[point_score].ScorePoint();
        point_score++;
    }

    


}
