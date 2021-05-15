using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// User interface to access all other managers.
    /// </summary>
    public class Game_Manager : MonoBehaviour
    {
        private static Game_Manager gameManager;
        static Scene_Manager sceneManager;
        static PlayerManager playerManager;

        private void Awake()
        {
            //prevent more than one manager from ever exsiting 
            DontDestroyOnLoad(this.gameObject);
            if (gameManager == null) gameManager = this;
            else { Destroy(this.gameObject); }

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
