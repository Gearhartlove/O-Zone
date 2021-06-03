using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stage : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    static Stage stage;
    //NOTE: 
    //not sure how static will interact with multiple stages
    //when loading, I think it will be fine
    public Stage GetStage => stage;
    [SerializeField] Tilemap TileMap_;

    private void Awake()
    {
        if (stage == null)
        {
            stage = GetComponent<Stage>();
        }
    }

    public static Stage Assign_Stage(Stage stageREF)
        => stage;
    //for debugging purposes
    public void DB_PrintSpawns()
    {
        foreach (GameObject go in SpawnPoints)
        {
            Debug.Log(go.transform.position);
        }
    }
}
