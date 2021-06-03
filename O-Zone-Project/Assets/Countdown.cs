using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    //Components
    private static Countdown countdown;
    static Animator animator;
    static CanvasGroup canvas_group;
    //Variables
    public static bool StartTimer = false;
    static float countdown_delay = 3f;
    public static float GetCountdown_Delay => countdown_delay;
    private float TempTimer = 0f;
    [SerializeField] TMPro.TextMeshProUGUI countdown_text;

    private void Awake()
    {
        //because static, need to prevent from assigning again
        DontDestroyOnLoad(gameObject);
        if (countdown == null) countdown = GetComponent<Countdown>();
        else { Destroy(gameObject); }
        if (canvas_group == null) canvas_group = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //only run when the Countdown timer has started
        //(after the scoreboard is hidden)
        if (StartTimer)
        {
            TempTimer += Time.deltaTime;
            if (TempTimer >= 3f)
            {
                //hide the UI
                StopCountdown();
            }
            else if (TempTimer >= 2f)
            {
                //Display 3
                countdown_text.text = "1";
                countdown_text.fontSize = 110;
                //audio
            }
            else if (TempTimer >= 1f)
            {
                //Display 2
                countdown_text.text = "2";
                countdown_text.fontSize = 95f;
                //audio
            }
            else
            {
                //Display 1
                countdown_text.text = "3";
                countdown_text.fontSize = 80f;
                //audio
            }
        }
    }

    public static void StartCountdown()
    {
        canvas_group.alpha = 1f;
        StartTimer = true;
    }

    public void StopCountdown()
    {
        //reset text 
        countdown_text.text = "3";
        countdown_text.fontSize = 80f;
        //hide countdown
        StartTimer = false;
        TempTimer = 0f;
        canvas_group.alpha = 0f;
    }
}
