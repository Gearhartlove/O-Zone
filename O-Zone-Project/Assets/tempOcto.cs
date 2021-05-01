using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempOcto : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger entered");
    }
}
