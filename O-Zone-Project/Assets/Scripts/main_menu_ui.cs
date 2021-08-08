using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;

public class main_menu_ui : MonoBehaviour
{
    [SerializeField]
    private GameObject PressButton;

    [SerializeField]
    private GameObject EnterArea;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.PCount > 0)
        {
            PressButton.GetComponent<Image>().enabled = false;
            EnterArea.GetComponent<Image>().enabled = true;
        }
    }
}
