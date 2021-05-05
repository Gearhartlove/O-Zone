using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// user interface to access all other managers
/// </summary>
public class GameManager : MonoBehaviour
{
    SceneManager sceneManager;
    PlayerManager playerManager;

    private void Awake()
    {
        sceneManager = gameObject.GetComponent<SceneManager>();
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    public SceneManager GetSM => sceneManager;
    public PlayerManager GetPM => playerManager;
}
