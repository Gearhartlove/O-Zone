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
        static Transform PTransform;
        static GameObject PGameObj;
        static Rigidbody2D PRigidBody;

        /// <summary>
        /// set each variable to the component on the Octo
        /// </summary>
        void Awake()
        {
            PControls = gameObject.GetComponent<PlayerControls>();
            PAnimator = gameObject.GetComponent<Animator>();
            PStats = gameObject.GetComponent<PlayerStats>();
            PTransform = gameObject.transform;
            PGameObj = gameObject;
            PRigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// //get methods, used for accessing the Octo's components
        /// </summary>
        public static PlayerControls GetPControls => PControls;
        public static Transform GetPTransform => PTransform;
        public static GameObject GetPGameObject => PGameObj;
        public static Rigidbody2D GetPRigidBody => PRigidBody;
        public static Animator GetPAnimator => PAnimator;
        public static PlayerStats GetPStats => PStats;


    }
}