using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{

    public class PlayerComponents : MonoBehaviour
    {
        static PlayerControls PControls;
        static Animator PAnimator;
        static PlayerStats PStats;

        /// <summary>
        /// set each variable to the component on the Octo
        /// </summary>
        void Awake()
        {
            PControls = gameObject.GetComponent<PlayerControls>();
            //PAnimator = gameObject.GetComponent<Animator>();
            PStats = gameObject.GetComponent<PlayerStats>();
        }

        /// <summary>
        /// //get methods, used for accessing the Octo's components
        /// </summary>
        public static PlayerControls GetPControls => PControls;
        //public static Animator GetPAnimator => PAnimator;
        public static PlayerStats GetPStats => PStats;


    }
}