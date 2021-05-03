using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{ 
    [SerializeField] Canvas UICanvas;
    //transitioning between scenes, incrementing wins

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
}
