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
        public static Scene_Manager GetSM => sceneManager;
        static PlayerManager playerManager;
        public static PlayerManager GetPM => playerManager;
        static StageManager stageManager;
        public static  StageManager GetStageManager => stageManager;

        private void Awake()
        {
            //prevent more than one manager from ever exsiting 
            DontDestroyOnLoad(this.gameObject);
            if (gameManager == null) gameManager = this;
            else { Destroy(this.gameObject); }

            sceneManager = GetComponent<Scene_Manager>();
            playerManager = GetComponent<PlayerManager>();
            stageManager = GetComponent<StageManager>();

        }

        public static int GetRandomNumber(int BoundedBy)
        {
            //Generate a random number between 0 an BoundedBy
            return Random.Range(0, BoundedBy);
        }
    }
}
