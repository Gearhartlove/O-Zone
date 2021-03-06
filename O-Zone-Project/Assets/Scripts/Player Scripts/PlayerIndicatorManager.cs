using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicatorManager : MonoBehaviour
{
    private static List<GameObject> Indicators;
    [SerializeField] GameObject Indicator;
    static Canvas canvas;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (Indicators == null)
            Indicators = new List<GameObject>();
        else { Destroy(gameObject); }

        if (canvas == null)
            canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //camera resets each time a new scene is loaded, reassigns camera
        //to the scene camera
        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = GameObject.Find("Main Camera")
                .GetComponent<Camera>();
        }

        for (int i = 0; i < PlayerManager.PCount; i++)
        {
            if (PlayerManager.PArray[i].GetComponent<PlayerStats>().CurrentHealth != 1)
            {
                GameObject CurrentIndicator = Indicators[i];
                CurrentIndicator.transform.Find("Skull").GetComponent<Image>().enabled = false;
            } else
            {
                GameObject CurrentIndicator = Indicators[i];
                CurrentIndicator.transform.Find("Skull").GetComponent<Image>().enabled = true;
            }
            Vector3 octoPosition = PlayerManager.PArray[i].transform.position;
            Vector3 newPosition = octoPosition;
            newPosition.y += 0.75f;
            Indicators[i].transform.position = newPosition;
        }
    }


    public void AddPlayerIndicator()
    {
        GameObject newIndicator = Instantiate(Indicator, transform, false);
        Indicators.Add(newIndicator);
    }
}
