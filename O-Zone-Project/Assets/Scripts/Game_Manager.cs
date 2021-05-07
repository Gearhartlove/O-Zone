using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// user interface to access all other managers
    /// </summary>
    public class Game_Manager : MonoBehaviour
    {
        static SceneManager sceneManager;
        static PlayerManager playerManager;

        private void Awake()
        {
            sceneManager = gameObject.GetComponent<SceneManager>();
            playerManager = gameObject.GetComponent<PlayerManager>();
        }

        public static SceneManager GetSM => sceneManager;
        public static PlayerManager GetPM => playerManager;

        public static int GenRN(int BoundedBy)
        {
            //Generate a random number between 0 an BoundedBy
            return Random.Range(0, BoundedBy);
        }
    }
}
