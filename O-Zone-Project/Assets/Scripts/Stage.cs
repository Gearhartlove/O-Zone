using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Each stage is associated with a scene, which are stored in StageManager.
/// The Stage class will hold the information specific to each stage. This
/// includes the spawn points and . . .
/// </summary>
public class Stage : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    static Stage stage;

    private void Awake()
    {
        if (stage == null) stage = GetComponent<Stage>();
    }

    //for debugging purposes
    public void DB_PrintSpawns()
    {
        foreach (GameObject go in SpawnPoints)
        {
            Debug.Log(go.transform.position);
        }
    }
}
