using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Manager.Game_Manager;

public class StartZone : MonoBehaviour
{
    [SerializeField] Slider slider;
    bool InZone = false;
    int PInZone = 0;
    //increment and decrement the progress bar
    private float increment_value = 0.5f;
    private float decrement_value = 1.5f;

    private void Update()
    {
       if (InZone && PInZone == GetPM.PCount)
       {
            //increment progress bar
            slider.value += increment_value * Time.deltaTime;
            if (slider.value == slider.maxValue)
                SceneManager.LoadScene(1);
       }
       else
       {
            slider.value -= decrement_value * Time.deltaTime;
       }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InZone = true;
            PInZone++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InZone = false;
            PInZone--;
        }
    }
}
