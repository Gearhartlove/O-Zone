using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int round_win_count;

    public void RoundWin() { round_win_count++; }
}
