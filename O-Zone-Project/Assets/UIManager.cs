using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject[] Skulls;
    // Start is called before the first frame update
    void Awake()
    {
        Skulls = new GameObject[4];
        int currentSkullCount = 0;
        for (int i = 1; i <= transform.childCount; i++)
        {
            string skull;
            skull = "Skull" + i.ToString();
            Transform result = transform.Find(skull);
            if (result)
            {
                Skulls[currentSkullCount] = result.gameObject;
                currentSkullCount++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PlayerManager.PCount; i++)
        {
            if (PlayerManager.PArray[i].GetComponent<PlayerStats>().CurrentHealth != 1)
            {
                Skulls[i].GetComponent<Image>().enabled = false;
            } else
            {
                Skulls[i].GetComponent<Image>().enabled = true;
            }
            Vector3 octoPosition = PlayerManager.PArray[i].transform.position;
            Vector3 newPosition = octoPosition;
            newPosition.y += 0.75f;
            Skulls[i].transform.position = newPosition;
        }
    }
}
