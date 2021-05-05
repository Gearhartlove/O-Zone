using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartZone : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameManager GM;
    bool InZone = false;
    int PInZone = 0;
    //increment and decrement the progress bar
    private float increment_value = 0.5f;
    private float decrement_value = 1.5f;

    private void Update()
    {
       if (InZone && PInZone == GM.GetPM.PCount)
       {
            //increment progress bar
            slider.value += increment_value * Time.deltaTime;
            if (slider.value == slider.maxValue)
                Debug.Log("start game");
       }
       else
       {
            slider.value -= decrement_value * Time.deltaTime;
       }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InZone = true;
        PInZone++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InZone = false;
        PInZone--;
    }
}
