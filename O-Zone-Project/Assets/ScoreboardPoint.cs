using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardPoint : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ScorePoint()
    {
        animator.Play("Crown_Win");
    }

    public void LosePoint()
    {
        animator.Play("Crown_Empty");
    }
}
