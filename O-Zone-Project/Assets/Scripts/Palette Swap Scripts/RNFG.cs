using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNFG : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int RNG = Random.Range(0, 6);
        GetComponent<Animator>().SetInteger("RNG", RNG);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
