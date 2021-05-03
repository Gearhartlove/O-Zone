using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartZone : MonoBehaviour
{
    [SerializeField] int PCount = 1; //temp till game manager exists
    [SerializeField] int PInZone = 0;
    [SerializeField] Slider slider;
    bool InZone = false;
    //increment and decrement the progress bar
    private float increment_value = 0.5f;
    private float decrement_value = 1.5f;

    private void Update()
    {
       if (InZone && PInZone == PCount)
       {
            //increment progress bar
            slider.value += increment_value * Time.deltaTime;
            if (slider.value == 1f) Debug.Log("start game");
            //if bar = 100%, start the game 
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
