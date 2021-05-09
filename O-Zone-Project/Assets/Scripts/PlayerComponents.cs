using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{

    public class PlayerComponents : MonoBehaviour
    {
        PlayerControls PControls;
        Animator PAnimator;
        PlayerStats PStats;
        Transform PTransform;
        GameObject PGameObj;
        Rigidbody2D PRigidBody;

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
        public PlayerControls GetPControls => PControls;
        public Transform GetPTransform => PTransform;
        public GameObject GetPGameObject => PGameObj;
        public Rigidbody2D GetPRigidBody => PRigidBody;
        public Animator GetPAnimator => PAnimator;
        public PlayerStats GetPStats => PStats;


    }
}