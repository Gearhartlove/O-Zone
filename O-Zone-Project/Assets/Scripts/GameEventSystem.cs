using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GameEventSystem : MonoBehaviour
{
    static EventSystem ES;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (ES == null)
        {
            ES = GetComponent<EventSystem>();
        }
        else { Destroy(gameObject); }
    }
}
