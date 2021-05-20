using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Surface : MonoBehaviour
{
    [SerializeField] GameObject LavaSplash;
    private Vector3 SpawnPoint;
    private float WaitUntilSplash;
    private float CurrentWait;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnPoint = new Vector3(0, 0.8f, 0);
        CurrentWait = 0;
        WaitUntilSplash = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentWait < WaitUntilSplash)
        {
            CurrentWait += Time.deltaTime;
        } else
        {
            float xPos = Random.Range(-5.5f, 5.5f);
            WaitUntilSplash = Random.Range(0.1f, 2);
            CurrentWait = 0;
            SpawnPoint.x = xPos;
            Instantiate(LavaSplash, SpawnPoint, Quaternion.identity);
        }
    }
}
