using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //array of stages to add too
    //-> Main Menu will always be index 0
    //??try to loop through the SceneBuilder
    //and find how many of each stage -> not hardcoded

    private List<Stage> stages_list;

    private void Awake()
    {
        stages_list = new List<Stage>();
        LoadScenesAsync();
    }

    private int GetTotalSceneCount => SceneManager.sceneCountInBuildSettings;

    public void LoadScenesAsync()
    {
        StartCoroutine(LoopThroughScenes());
        Debug.Log("scenes looped");
    }

    private IEnumerator LoopThroughScenes()
    {
        yield return null;

        //Debug.Log("Total Scene Count: " + GetTotalSceneCount);
        //i = 1 to not load starting scene 2x (freezes application)
        for (int i = 1; i < GetTotalSceneCount; i++)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(i);
            asyncOperation.allowSceneActivation = false;
            Debug.Log("Pro :" + asyncOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%");

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //Change the Text to show the Scene is ready
                    Debug.Log("Press the space bar to continue");
                    //Wait to you press the space key to activate the Scene
                }

                yield return null;
            }
        }
    }
}
