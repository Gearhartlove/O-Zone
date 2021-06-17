using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Manager;

public class StageManager : MonoBehaviour
{
    //setting up stage types
    private String[] STAGE_TYPES;

    private List<String>[] my_stages; //debugging purposes
    private List<String> evil_list;
    private List<String> beach_list;
    private List<String> rocky_list;

    private void Awake()
    {
        //if you add to this list, must update the "DetermineStageType()"
        //method below
        STAGE_TYPES = new String[]
        {
            "evil",
            "beach",
            "rocky"
        };
        evil_list =  new List<String>();
        beach_list = new List<String>();
        rocky_list = new List<String>();

        my_stages = new List<String>[]
        {
            evil_list,
            beach_list,
            rocky_list
        };

        SeperateStages();

        //TODO initial stage type > make UI for later 
        CurrentStageType = beach_list; 
    }

    private void SeperateStages()
    {
        DirectoryInfo DI = new DirectoryInfo(@"Assets/Scenes");
        try
        {
            // Determine whether the directory exists.
            if (DI.Exists)
            {
                try
                {
                    FileInfo[] FI = DI.GetFiles();
                    // Indicate that the directory already exists.
                    for (int i = 0; i < FI.Length; i++)
                    {
                        //if not a .meta file
                        if (!FI[i].Name.EndsWith(".meta"))
                        {
                            //removes ".unity" from end of the stage
                            //important for loading the stages later
                            string stage_name = FI[i].Name.
                                Substring(0, FI[i].Name.Length - 6);
                            
                            //call method with switch statment for stage types
                            DetermineStageType(stage_name);
                        }

                    }
                    return;
                }
                catch (IndexOutOfRangeException e)
                {
                    Debug.Log("String out of bounds:\n" +
                        e.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The process failed: " + e.ToString());
        }
    }

    private void DetermineStageType(string stage_name)
    {
        if (stage_name.StartsWith("evil") || stage_name.StartsWith("Evil"))
            evil_list.Add(stage_name);
        else if (stage_name.StartsWith("beach") || stage_name.StartsWith("Beach"))
            beach_list.Add(stage_name);
        else if (stage_name.StartsWith("rocky") || stage_name.StartsWith("Rocky"))
            rocky_list.Add(stage_name);
    }

    //Debugging purposes
    private void PrintStages()
    {
        foreach (List<String> list in my_stages)
        {
            foreach (String s in list)
            {
                Debug.Log(s);
            }
        }
    }

    //--------------------------------------------------------------------
    //LoadingStages
    private List<string> CurrentStageType;
    public  List<string> GetCurrentStageList => CurrentStageType;

    //changed in the main menu when playes hit a button on the 
    public void ChangeStageType(List<string> stage_type)
    {
        CurrentStageType = stage_type;
    }

    public void LoadStageRandom()
    {
        int random_number = Game_Manager.GetRandomNumber(GetCurrentStageList.Count);
        SceneManager.LoadScene(GetCurrentStageList[random_number]);
    }

    public void LoadMainMenu()
    {
        //disconect all of the players and reset all information
        //TODO ^ 
        SceneManager.LoadScene("MainMenu");
    }
}
