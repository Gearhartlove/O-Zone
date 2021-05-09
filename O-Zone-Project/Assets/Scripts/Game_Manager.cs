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
        static Scene_Manager sceneManager;
        static PlayerManager playerManager;

        private void Awake()
        {
            sceneManager = GetComponent<Scene_Manager>();
            playerManager = GetComponent<PlayerManager>();
        }

        public static Scene_Manager GetSM => sceneManager;
        public static PlayerManager GetPM => playerManager;

        public static int GenRN(int BoundedBy)
        {
            //Generate a random number between 0 an BoundedBy
            return Random.Range(0, BoundedBy);
        }
    }
}
